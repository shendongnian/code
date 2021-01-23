        public ICollectionView CollectionView { get; set; }
        public MainWindow()
        {
            InitializeComponent(); 
            DataContext = this;
            CollectionView = CollectionViewSource.GetDefaultView(AllImages);
            new DynamicFiltering(CollectionView, this.TextBoxFilter);
        }
        <ListBox Name="VisualList" 
             DataContext="{Binding CollectionView}" 
             ItemsSource="{Binding}" 
             Width="Auto" 
             Grid.Row="1"/>
