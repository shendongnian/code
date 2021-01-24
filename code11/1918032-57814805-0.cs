    MyViewModel myViewModel = new MyViewModel();    
    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        Console.WriteLine("new -- " + e.NewTextValue + "-- old -- " + e.OldTextValue);
        Console.WriteLine("MyEntry --" + MySearchBar.Text);
        //Here can invoke FilterOccupationsList of MyViewModel 
        myViewModel.FilterOccupationsList(MySearchBar.Text);
    }
