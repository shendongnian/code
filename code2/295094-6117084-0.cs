    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.ClickMe.Click += new RoutedEventHandler(ClickMe_Click);
        }
        void ClickMe_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (workSender, workE) =>
            {
                string argument = (string)workE.Argument;
                // argument == "Some data"
                System.Threading.Thread.Sleep(2000);
            };
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync("Some data");
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.ResultsTextBlock.Text = "I'm done";
        }
    }
