    private void createPage()
        {
            ClientContext context = new ClientContext(URL);
            Site siteCollection = context.Site;
            Web site = context.Web;
            List pages = site.Lists.GetByTitle("Site Pages");
            Microsoft.SharePoint.Client.
            FileCreationInformation fileCreateInfo = new FileCreationInformation();
            fileCreateInfo.Url = "NewPage.aspx";
            context.Load(pages.RootFolder.Files.Add(fileCreateInfo));
            context.ExecuteQuery();
            context.Dispose();
        }
