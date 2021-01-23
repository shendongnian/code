    this.MyDataGrid.DataSource = MyDataSource;
    this.MyDataGrid.ItemDataBound += (s, ea) =>
    {
        if (ea.Item.Cells[1].ToString() == "19/01")
        {
            foreach (TableCell cell in ea.Item.Cells)
            {
    	    cell.BackColor = Color.Red;
            }
        }
    };
    this.MyDataGrid.DataBind();
