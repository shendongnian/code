    private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        //...
        e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
    }
