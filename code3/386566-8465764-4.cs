    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Initialize UI
            InitializeComponent();
            // Process data
            ProcessDataAsync(new ParameterClass { Value = 20 });
        }
        /// <summary>
        /// Processes data asynchronously
        /// </summary>
        /// <param name="myClass"></param>
        private void ProcessDataAsync(ParameterClass myClass)
        {
            // Background worker
            var myWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
            };
            // Do Work
            myWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                // Set result
                e.Result = MyLongCalculations(myClass);
                // Update progress (50 is just an example percent value out of 100)
                myWorker.ReportProgress(50);
            };
            // Progress Changed
            myWorker.ProgressChanged += delegate(object sender, ProgressChangedEventArgs e)
            {
                myProgressBar.Value = e.ProgressPercentage;
            };
            // Work has been completed
            myWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                // Work completed, you are back in the UI thread.
                TextBox1.Text = (int) e.Result;
            };
            // Run Worker
            myWorker.RunWorkerAsync();
        }
        
        /// <summary>
        /// Performs calculations
        /// </summary>
        /// <param name="myvalues"></param>
        /// <returns></returns>
        public int MyLongCalculations(ParameterClass myvalues)
        {
            //some calculations
            return (myvalues.Value*2);
        }
    }
    /// <summary>
    /// Custom class
    /// </summary>
    public class ParameterClass
    {
        public int Value { get; set; }
    }
