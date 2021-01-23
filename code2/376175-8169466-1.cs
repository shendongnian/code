    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    
    namespace TPLSpielwiese
    {
      /// <summary>
      /// Interaction logic for MainWindow.xaml
      /// </summary>
      public partial class MainWindow : Window
      {
        public MainWindow() {
          this.InitializeComponent();
        }
    
        private void Button_Click(object sender, RoutedEventArgs e) {
          TaskScheduler taskUI = TaskScheduler.FromCurrentSynchronizationContext();
          Task.Factory
            .StartNew(() =>
                        {
                          this.ShowLoadingScreen(true);
                        }, CancellationToken.None, TaskCreationOptions.None, taskUI)
            .ContinueWith((t) =>
                            {
                              //CalculateAndUpdateChart(chartControl, settings);
                              Thread.Sleep(1000);
                            }, CancellationToken.None, TaskContinuationOptions.None, taskUI)
            .ContinueWith((t) =>
                            {
                              this.ShowLoadingScreen(false);
                            }, CancellationToken.None, TaskContinuationOptions.None, taskUI);
        }
    
        private Window loadScreen;
    
        private void ShowLoadingScreen(bool showLoadingScreen) {
          if (showLoadingScreen) {
            this.loadScreen = new Window() {Owner = this, WindowStartupLocation = WindowStartupLocation.CenterOwner, Width = 100, Height = 100};
            this.loadScreen.Show();
          } else {
            this.loadScreen.Close();
          }
        }
      }
    }
