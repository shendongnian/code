        public ICollectionView CollectionView { get; set; }
        public MainWindow()
        {
            InitializeComponent(); 
            DataContext = this;
            collectionView = CollectionViewSource.GetDefaultView(AllImages);
            new DynamicFiltering(CollectionView, this.TextBoxFilter);
        }
        <ListBox Name="VisualList" 
             DataContext="{Binding CollectionView}" 
             ItemsSource="{Binding}" 
             Width="Auto" 
             Grid.Row="1"/>
