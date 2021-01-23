            private string GetVirtualPath(string physicalPath)
            {
                string rootpath = Server.MapPath("~/");
    
                physicalPath = physicalPath.Replace(rootpath, "");
                physicalPath = physicalPath.Replace("\\", "/");
    
                return "~/" + physicalPath;
            }
