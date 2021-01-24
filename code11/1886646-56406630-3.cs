    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    
    namespace WpfApp
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private string TotalTime;
            private CancellationTokenSource cts;
    
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                cts = new CancellationTokenSource();
                TotalTimer("00:00:00", cts.Token);
            }
    
            async void TotalTimer(string time, CancellationToken token)
            {
                try
                {
                    while (!token.IsCancellationRequested)
                    {
                        TimeSpan timesp = DateTime.Now - DateTime.Parse(time);
                        TotalTime = timesp.Hours + " : " + timesp.Minutes + " : " + timesp.Seconds;
                        label1.Content = TotalTime;
                        await Task.Delay(5000, token);
                    }
                }
                catch(TaskCanceledException)
                {
                    label1.Content = "Canceled";
                }
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                cts.Cancel();
            }
        }
    }
