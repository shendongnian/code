     try
            {
                WebClient cl = new WebClient();
                cl.UseDefaultCredentials = true;
                byte[] data = cl.DownloadData(URL);
            }
            catch (exception ex)
            {
            }
  
