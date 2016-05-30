using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using xZune.Vlc.Interop;
using xZune.Vlc.Interop.MediaPlayer;
using SEDO.VideoCaptureLibrary;
using System.Threading;
using SEDO.VideoCaptureLibrary.Rtp;
using Ganjubus;


namespace Cursant_Control
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public RtpClient VideoDevice { get; private set; }
        private bool IsGridSettingsOpen{ get; set; }


        public MainWindow()
        {
            InitializeComponent();
            IsGridSettingsOpen = false;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void BtnArrow_Click(object sender, RoutedEventArgs e)
        {
            GridSettingsAnimation();
            IsGridSettingsOpen = true;
        }

        private void GridSettingsAnimation()
        {
            if (IsGridSettingsOpen)
            {
                DoubleAnimation da = new DoubleAnimation();
                da.From = GridSettings.ActualWidth;
                da.To = 0;
                da.Duration = TimeSpan.FromSeconds(1);

                BtnArrow.Visibility = Visibility.Visible;
                ThicknessAnimation ta = new ThicknessAnimation();
                Thickness thick = new Thickness(-column1.ActualWidth, 0, 0, 0);
                ta.From = new Thickness(0, 0, 0, 0);
                ta.To = thick;
                ta.Duration = TimeSpan.FromSeconds(1);
                GridSettings.BeginAnimation(Grid.MarginProperty, ta);
                GridSettings.BeginAnimation(Grid.WidthProperty, da);
            }
            else
            {
                GridSettings.Width = 0;
                DoubleAnimation da = new DoubleAnimation();
                da.From = 0;
                da.To = column1.ActualWidth;
                da.Duration = TimeSpan.FromSeconds(1);

                BtnArrow.Visibility = Visibility.Hidden;
                GridSettings.Visibility = Visibility.Visible;
                ThicknessAnimation ta = new ThicknessAnimation();
                Thickness thick = new Thickness(-column1.ActualWidth, 0, 0, 0);
                ta.From = thick;
                ta.To = new Thickness(0, 0, 0, 0);
                ta.Duration = TimeSpan.FromSeconds(1);
                GridSettings.BeginAnimation(Grid.MarginProperty, ta);
                GridSettings.BeginAnimation(Grid.WidthProperty, da);
            }
        }
        private void BtnArrowPanel_Click(object sender, RoutedEventArgs e)
        {
            GridSettingsAnimation();
            IsGridSettingsOpen = false;  
        }

        private void Window_OnResize(object sender, SizeChangedEventArgs e)
        {
            if (IsGridSettingsOpen)
            { 
                GridSettings.Width = column1.ActualWidth;
                GridSettings.Height = MainGrid.ActualHeight;
            }
        }

        private void BtnFrontalCameraActivate_Click(object sender, RoutedEventArgs e)
        {
            BtnFrontalCameraActivate.Width = column1.ActualWidth;
        }


    }
}
