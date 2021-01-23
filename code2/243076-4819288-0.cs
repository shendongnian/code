    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        GridView gridView = (GridView)listView.View;
        gridView.Columns.CollectionChanged += new NotifyCollectionChangedEventHandler(Columns_CollectionChanged);
    }
    void Columns_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == NotifyCollectionChangedAction.Move)
        {
            //sender contains the order of the columns
        }
    }
