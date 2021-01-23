    public void Init(HttpApplication context)
    {
        context.PostMapRequestHandler += new EventHandler(context_PostMapRequestHandler);
    }
    
    void context_PostMapRequestHandler(object sender, EventArgs e)
    {
       HttpContext context = ((HttpApplication)sender).Context;
       Page page = HttpContext.Current.CurrentHandler as Page;
    }
