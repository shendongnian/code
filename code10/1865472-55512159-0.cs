     static void Main(string[] args)
            {
                string siteUrl = "http://sp2016/sites/dev";
                ClientContext clientContext = new ClientContext(siteUrl);
                var list = clientContext.Web.Lists.GetByTitle("Documents");
                var listItem = list.GetItemById(5);
                clientContext.Load(list);
                clientContext.Load(listItem, i => i.File);
                clientContext.ExecuteQuery();
    
                var fileRef = listItem.File.ServerRelativeUrl;
                var fileInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(clientContext, fileRef);
                var fileName = Path.Combine(@"C:\Test", (string)listItem.File.Name);
                using (var fileStream = System.IO.File.Create(fileName))
                {
                    fileInfo.Stream.CopyTo(fileStream);
                }
            }
