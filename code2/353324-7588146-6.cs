    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            var redBrush = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
            var greenBrush = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
            var blueBrush = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
            this.DataContext = new MainViewModel
            {
                Nodes = new ObservableCollection<NodeViewModel>{
                    new NodeViewModel 
                    { 
                        NodeColor = redBrush,
                        Children = new ObservableCollection<NodeViewModel>{
                            new NodeViewModel { NodeColor = greenBrush, LeftOffset = 65, TopOffset = 10},
                            new NodeViewModel { NodeColor = greenBrush, LeftOffset = 55, TopOffset = 60}
                        }
                    }, //red
                    new NodeViewModel { NodeColor = greenBrush}, //green
                    new NodeViewModel { NodeColor = blueBrush} //blue
                }
            };
        }
    }
    public class MainViewModel
    {
        public ObservableCollection<NodeViewModel> Nodes { get; set; }
    }
