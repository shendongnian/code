    private void createPage()
        {
            ClientContext context = new ClientContext(URL);
            Site siteCollection = context.Site;
            Web site = context.Web;
    
            List pages = site.Lists.GetByTitle("Site Pages");
    
            Microsoft.SharePoint.Client.
            FileCreationInformation fileCreateInfo = new FileCreationInformation();
            fileCreateInfo.Url = "NewPage.aspx";
            fileCreateInfo.Content = System.Text.Encoding.ASCII.GetBytes("Test");
            context.Load(pages.RootFolder.Files.Add(fileCreateInfo));
    
            context.ExecuteQuery();
            context.Dispose();
        }
