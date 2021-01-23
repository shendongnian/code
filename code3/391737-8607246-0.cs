    private DataTable GetData()
    {
        var result = new DataTable();
        result.Columns.Add("ColumnToGroupBy", typeof(string));
        result.Columns.Add("AnotherColumn", typeof(int));
        result.Columns.Add("YetAnotherColumn", typeof(string));
        result.Rows.Add(new object[] { "ca", 3, "abc" });
        result.Rows.Add(new object[] { "ca", 4, "cake" });
        result.Rows.Add(new object[] { "ro", 8, "apple" });
        result.Rows.Add(new object[] { "ro", 1, "pair" });
        result.Rows.Add(new object[] { "ef", 2, "okra" });
        return result;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        var data = GetData();
        var groupedData = from row in data.AsEnumerable()
                            group row by row.Field<string>("ColumnToGroupBy") into grouping
                            select grouping;
        foreach (var group in groupedData)
        {
            TableRow row = null;
            foreach (var item in group)
            {
                row = new TableRow();
                row.Cells.Add(new TableCell() { Text = item.Field<string>("ColumnToGroupBy") });
                row.Cells.Add(new TableCell() { Text = item.Field<string>("YetAnotherColumn") });
                myTable.Rows.Add(row);
            }
            row.CssClass = "CssClassThatSetsTheBottomBorder";
        }
    }
