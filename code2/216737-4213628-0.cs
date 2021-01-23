    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            var dataSet = getData();
            _rootNodes = dataSet.Tables["data"].DefaultView;
            _rootNodes.RowFilter = "ParentId IS NULL";
            this.DataContext = this;
        }
        private DataView _rootNodes;
        public DataView RootNodes
        {
            get { return _rootNodes; }
        }
        internal static DataSet getData()
        {
            ...
        }
    }
