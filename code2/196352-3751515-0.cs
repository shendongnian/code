        public UserControl1()
        {
            InitializeComponent();
            list = new BindingList<ListViewItem>();
            list.ListChanged += new ListChangedEventHandler(list_ListChanged);
        }
        void list_ListChanged(object sender, ListChangedEventArgs e)
        {
            MessageBox.Show(e.ListChangedType.ToString());
        }
        private BindingList<ListViewItem> list;
        public BindingList<ListViewItem> List1
        {
            get { return list; }
        }
