    public MainWindow()
    {
        InitializeComponent();
        XmlFileInfoCollection = new ObservableCollection<XmlFileInfo>();
        this.DataContext = this;
    }
    public ObservableCollection<XmlFileInfo> XmlFileInfoCollection
    {
        get;
        private set;
    }
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        CreateLibrary();
    }
    public void CreateLibrary()
    {
        string[] dirs = Directory.GetFiles(@"C:\Windows.old\Users\Michael\Desktop\data\fixtures\", "*.xml",       
                                           SearchOption.AllDirectories);
        foreach (string dir in dirs)
        {
            string fixture = System.IO.Path.GetFileName(dir);
            XmlFileInfo xmlFileInfo = new XmlFileInfo(fixture, dir);
            XmlFileInfoCollection.Add(xmlFileInfo);
        }
    }
