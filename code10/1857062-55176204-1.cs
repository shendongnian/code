    protected void hyperLink_Init(object sender, EventArgs e)
    {
        ASPxHyperLink link = (ASPxHyperLink)sender;
        GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;
    
        int rowVisibleIndex = templateContainer.VisibleIndex;
        
        //get the values of other column in the row
        string eventid = templateContainer.Grid.GetRowValues(rowVisibleIndex, "EventId").ToString();
        string id = templateContainer.Grid.GetRowValues(rowVisibleIndex, "Id").ToString();
        
        //create url
        string contentUrl = string.Format("events.aspx?eventid={0}&id={1}", eventid, id);
    
        link.NavigateUrl = contentUrl;
        link.Text = string.Format("Link Text Goes Here");
    }
