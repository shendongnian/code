      void Item_Bound(Object sender, DataGridItemEventArgs e) 
      {
 
         if((e.Item.ItemType == ListItemType.Item) || 
             (e.Item.ItemType == ListItemType.AlternatingItem))
         {
 
            Integer intButtonColumn = ###
            Button btn = e.Item.Cells[intButtonColumn].FindControls[0];
            btn.Visible = IsUserInRole();       
         }         
 
      }
