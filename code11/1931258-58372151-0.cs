    private void nameTB_TextChanged(object sender, EventArgs e)
    {
        browseDataTable.DefaultView.RowFilter = "name LIKE '%" + nameTB.Text + "%'";
        visibleDataTable = browseDataTable.DefaultView.ToTable().AsEnumerable().Take(100).CopyToDataTable();
        datagridview1.DataSource = visibleDataTable;
    }
