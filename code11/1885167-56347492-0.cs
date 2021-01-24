    <asp:Repeater ID="repeaterMaquinaCaida" runat="server" OnItemDataBound="ItemDataBound"
    
    void ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
      // Execute the following logic for Items and Alternating Items.
      if (e.Item.ItemType == ListItemType.Item ||
          e.Item.ItemType == ListItemType.AlternatingItem)
      {
        if (((Evaluation)e.Item.DataItem).Rating == "Good") //check your logic here
        {
          ((Label)e.Item.FindControl("RatingLabel")).Text= "<b>***Good***</b>"; //change row here
        }
      }
    } 
