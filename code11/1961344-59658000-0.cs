     static void Main(string[] args)
            {
                string password = "*******";
                string account = "user@Tenant.onmicrosoft.com";
                var secret = new System.Security.SecureString();
                foreach (char c in password)
                {
                    secret.AppendChar(c);
                }
    
                var credentials = new SharePointOnlineCredentials(account, secret);
                using (ClientContext ctx = new ClientContext("https://Tenant.sharepoint.com/sites/sitename/"))
                {
    
                    ctx.Credentials = new SharePointOnlineCredentials(account, secret);
                    ctx.Load(ctx.Web);
                    ctx.ExecuteQuery();
                    writeLogsintoList(ctx, "TestCategory", "TestMethod", "TestErrorMessage");
                    
                   
                }
            }
            public static void writeLogsintoList(ClientContext context, string Category_Name, string Method_Name, string Error_Message)
            {
                try
                {
                  
                    List announcementsList = context.Web.Lists.GetByTitle("Logs");
                    ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                    ListItem newItem = announcementsList.AddItem(itemCreateInfo);
    
                    newItem["Timestamp"] = DateTime.Now;
                    newItem["Category_Name"] = Category_Name;
                    newItem["Method_Name"] = Method_Name;
                    newItem["Error_Message"] = Error_Message;
    
    
                    newItem.Update();
                    context.ExecuteQuery();
                    Console.WriteLine("added");
                    Console.ReadLine();
    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
