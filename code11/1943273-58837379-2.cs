    public partial class WaitWindow : Window
    {
        public WaitWindow()
        {
            InitializeComponent();
            Progress = new Progress<double>( progress => ProgressHandler( progress ) );
        }
        public IProgress<double> Progress { get; }
        private void ProgressHandler( double progress )
        {
            progressBar.Value = progress;
        }
    }
