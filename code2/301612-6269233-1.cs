    /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                BitmapImage splashScreenImageSource = new BitmapImage();
                splashScreenImageSource.BeginInit();
                splashScreenImageSource.UriSource = new Uri("Your_Image.png", UriKind.Relative);
                splashScreenImageSource.EndInit();
    
                splashScreenImage.Source = splashScreenImageSource;
            }
    
            public void AsynchronousExit()
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(worker_DoWork);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                worker.RunWorkerAsync();
            }
    
            private void worker_DoWork(object sender, DoWorkEventArgs e)
            {
                //Makes the thread wait for 5s before exiting.
                Thread.Sleep(5000);
            }
    
            private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                Environment.Exit(0);
            }
        }
