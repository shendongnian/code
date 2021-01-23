       static Object m_LockObject = new Object();
        public void Init(HttpApplication objApplication)
        {
            // Register event handler of the pipe line
            objApplication.BeginRequest += new EventHandler(this.ContextBeginRequest);
            objApplication.EndRequest += new EventHandler(this.ContextEndRequest);
        }
        public void ContextEndRequest(object sender, EventArgs e)
        {
            try
            {
                lock (m_LockObject)
                {
                    using (StreamWriter sw = new StreamWriter(@"C:\requestLog.txt", true))
                    {
                        sw.WriteLine("End request called at " + DateTime.Now.ToString() + "; URL: " + HttpContext.Current.Request.RawUrl.ToString());
                    }
                }
                // Write the response back to the caller
                HttpContext.Current.Response.Write("The page request is " + HttpContext.Current.Request.RawUrl.ToString());
            }
            catch
            {
            }
        }
        public void ContextBeginRequest(object sender, EventArgs e)
        {
            try
            {
                lock (m_LockObject)
                {
                    using (StreamWriter sw = new StreamWriter(@"C:\requestLog.txt", true))
                    {
                        sw.WriteLine("Begin request called at " + DateTime.Now.ToString() + "; URL: " + HttpContext.Current.Request.RawUrl.ToString());
                    }
                }
            }
            catch
            {
            }
        }
