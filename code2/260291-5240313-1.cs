    public void Init(HttpApplication context)
    {
        context.PostMapRequestHandler += OnPostMapRequestHandler;
    }
    void OnPostMapRequestHandler(object sender, EventArgs e)
    {
        HttpContext context = ((HttpApplication)sender).Context;
        Page page = HttpContext.Current.CurrentHandler as Page;
        if (page != null)
        {
            page.PreRenderComplete += OnPreRenderComplete;
        }
    }
    void OnPreRenderComplete(object sender, EventArgs e)
    {
        Page page = (Page) sender;
        // script injection here
    }
