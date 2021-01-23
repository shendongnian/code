        string Path = ConfigurationManager.AppSettings["FilePath"].ToString();
        string[] filesindirectory = Directory.GetFiles(Server.MapPath(Path));
        List<String> images = new List<string>(filesindirectory.Length);
        
        foreach (string item in filesindirectory)
        {
            //Make sure you use the slash and variable here 
            //Path+"/{0}"
            images.Add(String.Format(Path+"/{0}", System.IO.Path.GetFileName(item)));
        }
        RepeaterImages.DataSource = images;
        RepeaterImages.DataBind();
