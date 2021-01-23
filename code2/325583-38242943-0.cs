    protected void AspGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {    
      if(e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView v = (DataRowView)e.Row.DataItem;           
            
            if (e.Row.Cells.Count > 0 && e.Row.Cells[0] != null && e.Row.Cells[0].Controls.Count > 0)
            {
                HyperLink link = e.Row.Cells[0].Controls[0] as HyperLink;
                if (link != null)
                {                    
                        link.Text = "Edit";
                }               
            }       
        }
    }
