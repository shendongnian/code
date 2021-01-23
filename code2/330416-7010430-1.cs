    public partial class MainWindow : Window
    {
        private ProgressWindow _Progress;
        public MainWindow()
        {
            InitializeComponent();
            _Progress = new ProgressWindow();
            _Progress.ProgressChanged += OnProgressChanged;
        }
        private void OnProgressChanged(object sender, ProjectChangedEventArgs e)
        {
            //ToDo: Update whatever you like in your MainWindow
        }
    }
