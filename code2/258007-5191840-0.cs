            using (ClientContext context = new ClientContext(siteurl)) {
                context.AuthenticationMode = ClientAuthenticationMode.Default;
                List list = context.Web.Lists.GetByTitle(listname);
                context.Load(list);
                context.Load(list.RootFolder);
                context.ExecuteQuery();
                string url = siteurl.CombineUrl(list.RootFolder.ServerRelativeUrl).CombineUrl(listfolder).CombineUrl(name);
				FileCreationInformation fci = new FileCreationInformation();
				fci.Content = data;
				fci.Overwrite = true;
				fci.Url = url;
				Microsoft.SharePoint.Client.File file = list.RootFolder.Files.Add(fci);
				context.ExecuteQuery();
            }
