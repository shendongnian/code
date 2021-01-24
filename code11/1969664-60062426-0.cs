        private void SetTitle()
        {
            Label lbl = (Label)this.Master.FindControl("asplblTitle");
            string sPagePath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            System.IO.FileInfo oFileInfo = new System.IO.FileInfo(sPagePath);
            string sPageName = oFileInfo.Name;
            ResourceManager rm = new ResourceManager("RWA_WebForms.App_GlobalResources." + sPageName, Assembly.GetExecutingAssembly());
            lbl.Text = rm.GetString("Title", Thread.CurrentThread.CurrentCulture);
        } 
