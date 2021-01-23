    void ListView_ItemInserted(Object sender, ListViewInsertedEventArgs e)
      {
        if (e.Exception == null)
        {
          if (e.AffectedRows > 0)
          {
            flag = True;
          }
          else
          {
            flag = False;
          }
      }
    
    void ListView_Itemdeleted(Object sender, ListViewDeletedEventArgs e)
      {
        if (e.Exception == null)
        {
          if (e.AffectedRows > 0)
          {
            flag = True;
          }
          else
          {
            flag = False;
          }
      }
    
    
    void ListView_ItemUpdated(Object sender, ListViewUpdatedEventArgs e)
      {
        if (e.Exception == null)
        {
          if (e.AffectedRows > 0)
          {
            flag = True;
          }
          else
          {
            flag = False;
          }
      }
