    public void ProcessRequest (HttpContext context) {
            try
            {
                context.Response.ContentType = "image/jpg";
                string FileName = context.Request.Params["FileName"].ToString();
                string path = System.Configuration.ConfigurationManager.AppSettings["ProfilePhotoPath"].ToString()+FileName;
                byte[] pic = GetImage(path);
                if (pic != null)
                {
                    context.Response.WriteFile(path);
                }
            }
            catch (Exception ex)
            {
    
            }
    
    
        }
    
        private byte[] GetImage(string iconPath)
        {
            using (WebClient client = new WebClient())
            {
                byte[] pic = client.DownloadData(iconPath);
                //string checkPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +@"\1.png";
                //File.WriteAllBytes(checkPath, pic);
                return pic;
            }
        }
