    public MainWindow()
    {
        InitializeComponent();
        // Subscribe to the item selected event
        MyUC.ItemHasBeenSelected += UCButtonClicked;
        Names = new List<string>
        {
            "A",
            "B",
            "C"
        };
        DataContext = this;
    }
    void UCButtonClicked(object sender, UCComboButton.SelectedItemEventArgs e)
    {
        var value = e.SelectedChoice;
        // Do something with the value
    }
