    void LoadDataGrid(string command, DataGrid dataGrid)
    {
        ...
        DataTable dt = new DataTable();
        dt.Load(cmd.ExecuteReader());
        ...
        dt.Columns.Add("Distance", typeof(string));
        dataGrid.DataContext = dt;
    }
