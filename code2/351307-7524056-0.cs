    if (e.CommandName == "Add")
      {
        DropDownList Myddl = null;
        ClientClass client = new ClientClass();
    
       //Use this if button type is linkbutton
        GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
    
       //Use this if button type is Button
       //GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
    
        Myddl = row.FindControl("ddlClients") as DropDownList;
        if (Myddl != null)
           {
             updated = client.InsertUpdateClient(ClientID, 
               int.Parse(e.CommandArgument.ToString()), departmentID);
            }
        else
          { 
            Labels.Text = "There was an error updating this client";
           }
        }
