    public MainWindow()
    {
        InitializeComponent();
        myLabel2.Content = "new content myLabel2";
        myLabel3.Content = "new content myLabel3";
        Widget widgetItem = new Widget();
        widgetItem.Title = "new content myLabel1";
        // You could set this elsewhere, but I'm doing it here to simplify this example.
        myContentPresenter.Content = widgetItem;
    }
