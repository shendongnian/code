    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer = new DispatcherTimer();
        public Paragraph p = new Paragraph();
        public MainWindow()
        {
            InitializeComponent();
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += _timer_Tick;
        }
        private void _timer_Tick(object sender, EventArgs e)
        {
            string time = System.DateTime.Now.ToString() + "\n";
            Run r = new Run(time);
            p.Inlines.Add(r);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Run r = new Run("");
            p.Inlines.Add(r);
            richTextBox.Document.Blocks.Add(p);
            _timer.Start();
        }
    }
  
