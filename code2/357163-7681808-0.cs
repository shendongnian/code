     <asp:GridView AutoGenerateColumns="false" CssClass="grid" ID="gvOrders" DataSourceID="sqlDsOrders"
                runat="server" ShowHeader="true" EnableViewState="false"
                onrowcommand="gvOrders_RowCommand"
       >
       ........
     </asp:GridView >
     protected void gvOrders_RowCommand(Object sender, GridViewCommandEventArgs e)
     {
        // If multiple buttons are used in a GridView control, use the
        // CommandName property to determine which button was clicked.
        if(e.CommandName=="Lock")
        {
          // Convert the row index stored in the CommandArgument
          // property to an Integer.
          int index = Convert.ToInt32(e.CommandArgument);
          //dowork
    
        }
     }    
