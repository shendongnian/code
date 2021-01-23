    using System.Text;
    public void AddNewFile(string destUrl)
    {
        using (SPSite site = new SPSite(destUrl)) {
            using (SPWeb web = site.OpenWeb()) {
                byte[] bytes = Encoding.GetEncoding("UTF-8").GetBytes(
                    "This is a new file.");
                web.Files.Add(destUrl, bytes);
            }
        }
    }
