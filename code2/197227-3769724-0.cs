    protected void Application_Error(object sender, EventArgs e)
    {
        if (Context.Handler is IRequiresSessionState || 
            Context.Handler is IReadOnlySessionState)
        {
             // Session exists
             Session["mysession"] = "Some message";
        }
    }
