    protected void GridViewDisplayDocument_RowCreated()
    {
       var rowCount = GridViewDisplayDocument.Rows.Count;
       for (int i = 0; i < rowCount; i++)
       {
          var url = GridViewDisplayDocument.Rows[i].Cells[0].Text;
          if (url != string.Empty)
          {
             HyperLink link = new HyperLink();
             link.Target = "blank";
             link.Text = url;
             link.NavigateUrl =  url;
    
             GridViewDisplayDocument.Rows[i].Cells[0].Controls.Add(link);
           }
        } 
    } 
