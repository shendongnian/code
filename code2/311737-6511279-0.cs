    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
            //this.Loaded += (o, e) => { this.layout.DataContext = new ViewModel(); };
        }
    }
    public class ViewModel
    {
        public ViewModel()
        {
            this.SampleText = "Sample";
        }
        public string SampleText { get; set; }
    } 
