    protected void dataGrid_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType==DataControlRowType.Header)
                {
    
                    e.Row.Cells[index of the cell to hide].Visible =false;
                    
                }
            }
