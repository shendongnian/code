    private ObservableCollection<Item> Items;
    private void DataGrid_Loaded(object sender, RoutedEventArgs e)
    {
        using (var reader = new StreamReader("Assets\\Archive.csv",true))
        using (var csv = new CsvReader(reader))
        {
            var records = csv.GetRecords<Item>();
            Items = new ObservableCollection<Item>(records);           
        }
    
        MyDataGrid.ItemsSource = Items;           
    }
