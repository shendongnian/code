     protected void rptAlternateNames_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
     
                if (e.Item.DataItem != null)
                {
    
                    Image imageImportedData = ((Image)e.Item.FindControl("imgImportedData"));
                    if (MySession.IsImportedData)
                    {
                        imageImportedData.Visible = true;
                    }
                }
            }
        }
