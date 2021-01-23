    var dt = new DataTable();
    //AddColumns
    for (int c = 0; c < dim; c++)
        dt.Columns.Add(c.ToString(), typeof(double));
    //LoadData
    for (int r = 0; r < dim; r++)
        dt.LoadDataRow(arry[r]);
