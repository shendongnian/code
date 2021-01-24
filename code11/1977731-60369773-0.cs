                    protected void YourGridIdHere_RowCommand(object sender, GridViewCommandEventArgs e)
                    {
                        // If multiple buttons are used in a GridView control, use the
                        // CommandName property to determine which button was clicked.
                        if(e.CommandName=="Your command in CommandName")
                        {
                          // Convert the row index stored in the CommandArgument
                          // property to an Integer.
                          int index = Convert.ToInt32(e.CommandArgument);
                        
                          // Retrieve the row that contains the button clicked 
                          // by the user from the Rows collection.
                          GridViewRow row = YourGridIdHere.Rows[index];
                        
                          // Get data from current selected row.    
                          int ID_COL = 0; 
                          TableCell wantedData = row.Cells[ID_COL];
                          string str = wantedData.Text;
                        
                          // So on....
                    }
