    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
      {
        // Get the header row.
        GridViewRow headerRow = GridView1.HeaderRow;
        if(headerRow != null)
         {
            foreach (TableCell td in headerRow.Cells)
             {
                LinkButton lnkbtn = (LinkButton)td.Controls[0];
    
                 if (lnkbtn.Text == e.SortExpression)
                   {
                      if (GridView1.SortDirection == SortDirection.Ascending)
                      {
                          lnkbtn.Text += imgAsc;
                      }
                      else
                        lnkbtn.Text += imgDes;
                   }
             }        
         }
      }
