    protected void selectedBookList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row != null) && (e.Row.RowType == DataControlRowType.DataRow))
        {
            string test = DataBinder.Eval(e.Row.DataItem, "URL").ToString();
            if (test.Length == 0)
            {
                e.Row.Cells[3].Visible = false;
            }
            else
            {
                e.Row.Cells[3].Visible = true;
            }
        }
    }
