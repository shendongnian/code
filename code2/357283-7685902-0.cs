    protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
    {
       if (e.Item is GridEditableItem && e.Item.IsInEditMode)
       {
          GridEditFormItem geiEditedItem = e.Item as GridEditFormItem;
          geiEditedItem.Visible = true;
				
	      //Edit mode
          if (e.Item.DataItem is YourClass)
          {
             YourClass currentItem = (YourClass)e.Item.DataItem;
             DropDownList ddlAuthenticationMode= geiEditedItem.FindControl("ddlAuthenticationMode") as DropDownList;
             ddlAuthenticationMode.SelectedValue = currentItem.AuthenticatioMode.ToString();
          }
       }
    }
