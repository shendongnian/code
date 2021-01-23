    <ListView x:Name="uiList" ItemsSource="{Binding}">
        <ListView.DataContext>
            <XmlDataProvider x:Name="DataSource" Source="c:\XMLFile.xml" XPath="/root/item"  />
        </ListView.DataContext>
        <ListView.ItemTemplate>
            <DataTemplate>
                <Border Width="40" Height="40" Background="Gray">
                    <Label Content="{Binding Attributes[0]}" />
                </Border>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
...
    public MainWindow()
    {
        InitializeComponent();
        uiList.SelectionChanged += new SelectionChangedEventHandler(uiList_SelectionChanged);
    }
    void uiList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string sFile = @"c:\XMLFile.xml";
        XDocument oDoc = XDocument.Load(sFile);
        oDoc.Root.Add(
            new XElement("item", new XAttribute("name", "test3"))
        );
        oDoc.Save(sFile);
        XmlDataProvider oProv = uiList.DataContext as XmlDataProvider;
        oProv.Refresh();
    }
