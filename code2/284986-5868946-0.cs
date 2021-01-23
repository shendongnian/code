    protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            if (Context.Handler is IRequiresSessionState || Context.Handler is IReadOnlySessionState)
            {
                HttpContext context = HttpContext.Current;
                // Your Methods
            }
        }
