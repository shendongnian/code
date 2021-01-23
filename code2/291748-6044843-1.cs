    protected void test(object sender, EventArgs e)
    {
        foreach(var y in myDataGrid.Items)
        {
            LinkButton lb = ((y as TableRow).Cells[1].Controls[1] as LinkButton);
            lb.Enabled = false;
        }
    }
