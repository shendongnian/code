    if (e.Item.ItemType == ListItemType.Item || 
                     e.Item.ItemType == ListItemType.AlternatingItem)
    {
        Label LblHead = e.Item.FindControl("Label1") as Label;   
        string LanguageID = Globals.GetSuitableLanguage(Page);   
           
        if (LblHead != null && LanguageID == "ar")   
        {   
            LblHead.Attributes.Add("CssClass", "hed_logo2");   
        }   
    }   
