        // Global.asax
        public MvcApplication()
        {
            BeginRequest += new EventHandler(MvcApplication_BeginRequest);
        }
        void MvcApplication_BeginRequest(object sender, EventArgs e)
        {
             Debug.WriteLine("[Start] Requested Url: " + HttpContext.Current.Request.RawUrl);
        }
