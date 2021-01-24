    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var repo = new StudentsRepository();
        var res = repo.GetDataTable();
        DataGrid1.ItemsSource = res.AsDataView();
    }
