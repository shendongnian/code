            string userName = "user@tenant.onmicrosoft.com";
            string password = "***********";
            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }
            using (var clientContext = new ClientContext("https://tenant.sharepoint.com/sites/sitename"))
            {
                clientContext.Credentials = new SharePointOnlineCredentials(userName, securePassword);
                Web web = clientContext.Web;
                clientContext.Load(web);
                clientContext.ExecuteQuery();
                List targetList = clientContext.Web.Lists.GetByTitle("Product List");
                clientContext.Load(targetList);
                clientContext.ExecuteQuery();
                string siteCols = "Product";
                FieldCollection fieldCollection = clientContext.Web.AvailableFields;
                clientContext.Load(fieldCollection);
                clientContext.ExecuteQuery();
                Field myField = Enumerable.FirstOrDefault(fieldCollection, ft => ft.InternalName == siteCols);
                targetList.Fields.Add(myField);
                targetList.Update();
                clientContext.ExecuteQuery();
            }   
