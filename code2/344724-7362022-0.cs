    protected void view_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowIndex == 0)
            {
                TextBox txtBox = (TextBox)e.Row.FindControl("txtBoxId");
                txtBox.TextChanged += new EventHandler(txtBox_TextChanged);
            }
        }
    }
