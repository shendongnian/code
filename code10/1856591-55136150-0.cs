    protected void GridView1_DataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            column1 = e.Row.Cells[1].Text;
            //here you can give the column no that you want get like e.Row.Cells[1] 
            e.Row.Cells[1].Text="test";
           //you can set what you want like this
        }
    }
