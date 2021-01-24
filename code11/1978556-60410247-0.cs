           using (ClientContext ctx = new ClientContext("https://Tenant.sharepoint.com/"))
            {
                ctx.Credentials = new SharePointOnlineCredentials(account, secret);
                ctx.Load(ctx.Web,a=>a.AssociatedOwnerGroup.Users);
                ctx.ExecuteQuery();
                if (ctx.Web.AssociatedOwnerGroup!=null)
                {
                    foreach (var user in ctx.Web.AssociatedOwnerGroup.Users)
                    {
                        Console.WriteLine(user.Email);
                    }
                }
		   }
