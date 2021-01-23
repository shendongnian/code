    public partial class MainPage : UserControl
    {
        public ObservableCollection<Node> Nodes { get; set; }
        
        public MainPage()
        {
            InitializeComponent();
            this.Nodes = new Node("Root", Colors.Blue,
                                 new Node("File1", Colors.Black),
                                 new Node("File2", Colors.Black),
                                 new Node("Archive1", Colors.Red,
                                            new Node("File3", Colors.Magenta),
                                            new Node("File4", Colors.Magenta))
                                 ).SubItems;
            treeView1.DataContext = this;
        }
    }
