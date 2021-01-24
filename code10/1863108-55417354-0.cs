        protected void Page_Load(object sender, EventArgs e)
        {
            var token = HttpContext.Current.Request.Headers.Get("Authorization");
            PageAsyncTask t = new PageAsyncTask(() => GetUserClaims(token));
            // Register the asynchronous task.
            Page.RegisterAsyncTask(t);
            // Execute the register asynchronous task.
            Page.ExecuteRegisteredAsyncTasks();
            //GetUserClaims(token).ConfigureAwait(false).GetAwaiter().GetResult();          
        }
