    void menu_click (object sender, EventArgs e)
    {
       var clickedItem = sender as MenuItem;
     
       if (clickedItem == null) return;
    
       if (clickedItem.HasHeader)
       {
           var text = clickedItem.Header;
       }
    }
