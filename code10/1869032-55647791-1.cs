    using System;
    using System.Threading.Tasks;
    using System.Windows;
    
    namespace WpfApp1
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private async void Button1_Click(object sender, RoutedEventArgs e)
            {
                var progress = new Progress<double>(s => { ProgressBar1.Value = s; });
    
                await Task.Run(() => DoWork(progress));
            }
    
            private static async Task DoWork(IProgress<double> progress = null)
            {
                const int count = 100;
    
                for (var i = 0; i < count; i++)
                {
                    await Task.Delay(50);
    
                    progress?.Report(1.0d / (count - 1) * i);
                }
            }
        }
    }
