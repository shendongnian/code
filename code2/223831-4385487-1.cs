    using System.Text;
    public void UploadFile(string srcUrl, string destUrl)
    {
        if (!File.Exists(srcUrl)) {
            throw new ArgumentException(String.Format("{0} does not exist",
                srcUrl), "srcUrl");
        }
        using (SPSite siteCollection = new SPSite(destUrl)) {
            using (SPWeb site = siteCollection.OpenWeb()) {
                byte[] bytes = Encoding.GetEncoding("UTF-8").GetBytes(
                    "This is a new file.");
                site.Files.Add(destUrl, bytes);
            }
        }
    }
