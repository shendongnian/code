    public IQueryable<WebFile> GetFiles()
            {
    
                string path = "~/Upload";
    
                List<WebFile> webFiles = new List<WebFile>();
    
                if (string.IsNullOrEmpty(path)) return webFiles.AsQueryable();
    
                DirectoryInfo di = new DirectoryInfo(HttpContext.Current.Server.MapPath(path));
    
                foreach (FileInfo file in di.GetFiles())
                {
    
                    webFiles.Add(new WebFile { FileName = file.Name });
    
                }
    
                return webFiles.AsQueryable();
    
            }
    
            public void InsertFile(WebFile file)
            {
    
                FileHandler.HandleFile(file);
    
            }
