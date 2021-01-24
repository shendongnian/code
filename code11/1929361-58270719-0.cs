    private Widget my_widgetItem;
    public MainWindow()
    {
        InitializeComponent();
        myLabel2.Content = "new content myLabel2";
        myLabel3.Content = "new content myLabel3";
        my_widgetItem = new Widget();
        my_widgetItem.Title1 = "new content while initialization a";
        my_widgetItem.Title2 = "new content while initialization b";
        myContentPresenter.Content = my_widgetItem;
    }
    private void onClick(object sender, RoutedEventArgs e)
    {
        myLabel2.Content = "label changed"; /// O.K.
        my_widgetItem.Title2 = "new content after click";
    }
