    /// <summary>
    ///  property accessor for the Thumbnails 
    /// </summary>
    public ExtensionCollection<FeedLink> FeedLinks
    {
        get 
        {
            if (this.links == null)
            {
                this.links = new ExtensionCollection<FeedLink>(this); 
            }
            return this.links;
        }
    }
