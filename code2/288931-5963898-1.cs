    void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
     {
     // If multiple buttons are used in a GridView control, use the
     // CommandName property to determine which button was clicked.
     if(e.CommandName=="pdf_click")
      {
       // Convert the row index stored in the CommandArgument
       // property to an Integer.
       int index = Convert.ToInt32(e.CommandArgument);
 
       // Retrieve the row that contains the button clicked 
       // by the user from the Rows collection.
       GridViewRow row = ContactsGridView.Rows[index];
       // Now you have access to the gridviewrow.
      }  
    }   
