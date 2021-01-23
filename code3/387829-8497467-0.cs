    public partial class Form1 : Form
    {
        /// <summary>
        /// Timer.
        /// </summary>
        private Timer timer = new Timer();
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += BackgroundWorker1DoWork;
            backgroundWorker1.ProgressChanged += BackgroundWorker1ProgressChanged;
            timer.Interval = 500;
            timer.Tick += TimerTick;
        }
        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void TimerTick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            backgroundWorker1.ReportProgress(99);
        }
        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Button1Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            backgroundWorker1.RunWorkerAsync();
        }
        /// <summary>
        /// Handles the DoWork event of the backgroundWorker1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        private void BackgroundWorker1DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            // Do your work...
            Thread.Sleep(2000);
        }
        /// <summary>
        /// Handles the ProgressChanged event of the backgroundWorker1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.ProgressChangedEventArgs"/> instance containing the event data.</param>
        private void BackgroundWorker1ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label1.Visible = (e.ProgressPercentage == 99);
        }
    }
