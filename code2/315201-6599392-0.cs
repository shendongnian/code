    private void renderFeed(String uri)  
    {
        try  
        {  
            Label feed = new Label();
            feed.Name = uri;
            //Create a Syndicated feed reader, parse the XML and add the relevant text to the label "feed"
            feed.BorderStyle = System.Web.UI.WebControls.BorderStyle.Double;
            viewedFeeds.Add(uri);
            this.Controls.Add(feed);
        }
        catch (Exception ex)
        {   
            //Print an error message (e.g. If the URI does not link to a suitable feed
        }
    }
