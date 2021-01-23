        string filters = "*.jpg;*.png;*.gif";
        string Path = ConfigurationManager.AppSettings["FilePath"].ToString();
        
        List<String> images = new List<string>();
    
        foreach (string filter in filters.Split(';'))
        {
            FileInfo[] fit = new DirectoryInfo(this.Server.MapPath("~/images")).GetFiles(filter);
            foreach (FileInfo fi in fit)
            {
                images.Add(String.Format(Path + "/{0}", fi));                 
            }
        }
        RepeaterImages.DataSource = images;
        RepeaterImages.DataBind();
