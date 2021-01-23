     if(e.Item.ItemType == ItemType.Item || e.Item.ItemType == ItemType.AlternatingItem)
     {
          LinkButton myButton = (LinkButton)e.Item.FindControl("editbutton");
          myButton.OnClientClick = (popupWindow.GetTargetPopupCode("URL");
     }
