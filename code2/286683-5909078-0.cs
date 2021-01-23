    public string Makezipfile(string[] files)
        {
      string[] filenames = new string[files.Length];
        
            for (int i = 0; i < files.Length; i++)
                filenames[i] = HttpContext.Current.Request.PhysicalApplicationPath + files[i].Replace(HttpContext.Current.Request.UrlReferrer.ToString(), "");
        string DirectoryName = filenames[0].Remove(filenames[0].LastIndexOf('/'));
        DirectoryName = DirectoryName.Substring(DirectoryName.LastIndexOf('/') + 1).Replace("\\", "");
        try
        {
            string newFile = HttpContext.Current.Request.PhysicalApplicationPath + "your image directory\\" + DirectoryName + ".zip";
            if (File.Exists(newFile))
                File.Delete(newFile);
            using (ZipFile zip = new ZipFile())
            {
                foreach (string file in filenames)
                {
                    string newfileName = file.Replace("\\'", "'");
                    zip.CompressionLevel = 0;
                    zip.AddFile(newfileName, "");
                }
                zip.Save(newFile);
            }
        }
        catch (Exception ex)
        {
            //Console.WriteLine("Exception during processing {0}", ex);
            Response.Write(ex);
            // No need to rethrow the exception as for our purposes its handled.
        }
        string a;
        a = "your images/" + DirectoryName + ".zip";
        return a; 
    }
