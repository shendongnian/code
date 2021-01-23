    List<string> myItemsCollection = new List<string>();
    public Window1()
    {
       InitializeComponent();
       myItemsCollection.Add("Item1");
       myCombobox.ItemsSource = myItemsCollection;
    }
