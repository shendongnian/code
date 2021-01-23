    protected void myGridView_DataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // You may have to play with the index of the control
            // I have found that often a GridView will place a 
            // Literal control as Control[0] and the LinkButton
            // as Control[1]. Once you find the index, it won't
            // change.
            LinkButton btn = (LinkButton)e.Row.Cells[0].Controls[1];
            string text = btn.Text;
        }
    }
