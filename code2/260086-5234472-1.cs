    protected void gvNotes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex < 0)
            return;
        int _myColumnIndex = 0;   // Substitute your value here
        string text = e.Row.Cells[_myColumnIndex].Text;
        
        if (text.Length > 100)
        {
            e.Row.Cells[_myColumnIndex].Text = text.Substring(0, 100);
        }
    }
