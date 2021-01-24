    ObservableCollection<MyModel> entries = new ObservableCollection<MyModel>();
    for (var i = 0; i<files.Length; i++)
    {
    Console.WriteLine("app output - entry " + files[i]);
    
    var model = new MyModel
    {
        Text = "text value",
        Description = "description value"
    };
    
    entries.Add(model);
    }
    ItemsListView.ItemsSource = entries;
