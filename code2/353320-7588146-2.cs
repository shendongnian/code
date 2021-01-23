    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel
            {
                Nodes = new ObservableCollection<NodeViewModel>{
                    new NodeViewModel { NodeColor = new SolidColorBrush(Color.FromArgb(255,255,0,0))}, //red
                    new NodeViewModel { NodeColor = new SolidColorBrush(Color.FromArgb(255,0,255,0))}, //green
                    new NodeViewModel { NodeColor = new SolidColorBrush(Color.FromArgb(255,0,0,255))} //blue
                }
            };
        }
    }
    public class MainViewModel
    {
        public ObservableCollection<NodeViewModel> Nodes { get; set; }
    }
