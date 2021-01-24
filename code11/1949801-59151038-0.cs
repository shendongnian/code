            string password = "*******";
            string account = "username@tenant.onmicrosoft.com";
            var secret = new SecureString();
            foreach (char c in password)
            {
                secret.AppendChar(c);
            }
        using (ClientContext ctx = new ClientContext("https://tenant.sharepoint.com/sites/dev/"))
        {
            ctx.Credentials = new SharePointOnlineCredentials(account, secret);
            ctx.Load(ctx.Web);
            ctx.ExecuteQuery();
            List topicsList  = ctx.Web.Lists.GetByTitle("ListName");
            ListItemCreationInformation oListItemCreationInformation = new ListItemCreationInformation();
            ListItem oListItem  = topicsList.AddItem(oListItemCreationInformation);
            oListItem ["Title"] = "New List Item";
			oListItem["Column1"] = "Test1"; 
            oListItem .Update();
            ctx.ExecuteQuery();
       
        };
