    protected void lst_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
    {
        DataTable table = new DataTable();
        table.Columns.Add("Test", typeof(string));
        DataRow row = table.NewRow();
        row.SetField<string>("Test", "Testing");
        table.Rows.Add(row);
        row = table.NewRow();
        row.SetField<string>("Test", "Testing again");
        table.Rows.Add(row);
        lst.DataSource = table;
    }
    protected void lst_Command(object sender, RadListViewCommandEventArgs e)
    {
        lblCommandArg.Text = e.CommandArgument.ToString();
    }
