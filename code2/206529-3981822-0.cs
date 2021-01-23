    public override IHttpHandler GetHandler(HttpContext context, string requestType, string virtualPath, string path)
    {
        var handler = (Page)base.GetHandlerHelper(context, requestType, VirtualPath.CreateNonRelative(virtualPath), path);
        page.AppRelativeVirtualPath = "...";
        return page;
    }
