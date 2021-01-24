     protected void btnscreenshot_click(object sender, EventArgs e)
        {
            DataTable dt = null;
            var threadexample = new Thread(() =>
            {
                dt = GetData();
            });
            threadexample.Start();
            threadexample.Join();
            Session["ThreadTesting"] = dt;
         
        }
        protected DataTable GetData()
        {
            DataTable dt = new DataTable();
           //Do Your Process
            return dt;
        }
