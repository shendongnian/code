    public MainPage()
    {
        InitializeComponent();
        myEntry.TextChanged += MyEntry_TextChanged;
    }
    private void MyEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        if (entry.IsFocused)
        {
            //change from UI
            Console.WriteLine("change from UI");
        }
        else{
            //change from code
            Console.WriteLine("change from code");
        }
    }
