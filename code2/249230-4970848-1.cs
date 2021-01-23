    protected void Admin_menus_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        // Ensure that the ItemCreated is not null, the first one (header?) gets 
        // returned null
        if (e.Item.DataItem != null)
        {
            // Extract the "url" attribute from the Xml that's being used for 
            // databinding for this particular row, via casting it down to 
            // IXPathNavigable as the concrete type of e.Item.DataItem isn't available
            // to us.
            var currentUrl = ((IXPathNavigable)e.Item.DataItem).CreateNavigator().GetAttribute("url", "");
            if (Request.Url.PathAndQuery.Contains(currentUrl))
            {
                // This just adds a background color of "red" to the selected 
                // menu item. What you actually do is entirely up to you                
                var hyperlink = (HtmlGenericControl) e.Item.FindControl("hyperlink");
                hyperlink.Style.Add(HtmlTextWriterStyle.BackgroundColor, "red");
            }
        }
    }
