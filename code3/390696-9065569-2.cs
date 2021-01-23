    // This ensures that DynamicSiteMapProviders.ThisNode is not set to the node of a previously viewed page.
    // This is mainly for news and events pages that are not in the sitemap and are using the news and events listing page node as the current node.
    protected override void OnUnload(EventArgs e)
    {
        DynamicSiteMapProviders.ThisNode = null;
        base.OnUnload(e);
    }
