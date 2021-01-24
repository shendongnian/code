        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private async void Button_Click(object sender, RoutedEventArgs e)
            {
                CancellationTokenSource tokenSource = new CancellationTokenSource();
                Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate { ShowLoadingText(tokenSource.Token); }));
    
                await Task.Run(() => Thread.Sleep(5000)); // your parsing operation
    
                tokenSource.Cancel();
            }
    
            private async void ShowLoadingText(CancellationToken token)
            {
                txtLoading.Visibility = Visibility.Visible;
    
                try
                {
                    while (!token.IsCancellationRequested)
                    {
                        txtLoading.Text = "Loading";
                        await Task.Delay(500, token);
                        txtLoading.Text = "Loading.";
                        await Task.Delay(500, token);
                        txtLoading.Text = "Loading..";
                        await Task.Delay(500, token);
                        txtLoading.Text = "Loading...";
                        await Task.Delay(500, token);
                    }
                }
                catch (TaskCanceledException)
                {
                    txtLoading.Visibility = Visibility.Hidden;
                }
            }
        }
    }
