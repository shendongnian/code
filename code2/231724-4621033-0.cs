      private PropertyManagerModel.DemoDBEntityDiagrams context;
        public Form1()
        {
            InitializeComponent();
            context = new DemoDBEntityDiagrams();
            LoadCommunities();
        }
       private void LoadCommunities()
        {         
            var communityList = new ObservableCollection<Community>(context.Communities);
            communityList.CollectionChanged += new NotifyCollectionChangedEventHandler(communityList_CollectionChanged);
            this.dataGridView1.DataSource = new BindingSource() { DataSource=communityList};
        }
        void communityList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                context.Add(e.NewItems);
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                context.Delete(e.OldItems);
            context.SaveChanges();
        }      
