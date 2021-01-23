        /// <summary>
        /// The event occurs just after Initialization of Session, and before Page_Init event
        /// </summary>
        protected void Application_PreRequestHandlerExecute(Object sender, EventArgs e)
        {
            // here it checks if session is reuired, as
            // .aspx requires session, and session should be available there
            // .jpg, or .css does require session so session will be null
            // as .jpg, or .css are also http request in either case if you implemented URL Rewritter, or custom IHttp Module
            if (Context.Handler is IRequiresSessionState || Context.Handler is IReadOnlySessionState)
            {
                // here is your actual code
                // check if session is new one
                // or any of your logic
                if (Session.IsNewSession
                    || Session.Count < 1)
                {
                    // checking if request is not for default.aspx page, as it should not be redirected
                    if (!Context.Request.Url.AbsoluteUri.ToLower().Contains("/default.aspx"))
                    {
                        Context.Response.Redirect("~/default.aspx");
                    }
                }
            }
        }
