    foreach(MyNameValuePairProps pair in Props)
    {
        DataGridTextColumn column = x;// create column as you will
        column.Binding = new Binding("Value") { Source = pair};
        myDataGrid.Columns.Add(column);
    }
