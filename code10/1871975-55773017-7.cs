    public async Task<DataTable> GetDataTable()
    {
        var dataTable = new DataTable("Students");
        using (var conn = await DbContext.GetConnection())
        {
            var da = new SQLiteDataAdapter(GET_ALL_QUERY, conn);
            da.Fill(dataTable);
            conn.Close();
        }
        return dataTable;
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var repo = new StudentsRepository();
        var res = repo.GetDataTable();
        DataGrid1.ItemsSource = res.Result.AsDataView();
    }
