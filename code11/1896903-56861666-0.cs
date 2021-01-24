    string targetSiteURL = @"https://tenant.sharepoint.com/sites/lee";
    
                var login = "user@tenant.onmicrosoft.com";
                var password = "password";
    
                var securePassword = new SecureString();
    
                foreach (char c in password)
                {
                    securePassword.AppendChar(c);
                }
                SharePointOnlineCredentials onlineCredentials = new SharePointOnlineCredentials(login, securePassword);
    
                using (ClientContext clientContext = new ClientContext(targetSiteURL))
                {
                    clientContext.Credentials = onlineCredentials;
    
                    Web web = clientContext.Web;
                    clientContext.Load(web);                
                    clientContext.Load(web, wb => wb.ServerRelativeUrl);
                    clientContext.ExecuteQuery();
    
                    List list = web.Lists.GetByTitle("mydoc3");
                    clientContext.Load(list);                
    
                    Folder folder = web.GetFolderByServerRelativeUrl(web.ServerRelativeUrl + "/mydoc3/ParentFolder/");
                    clientContext.Load(folder);
                    clientContext.ExecuteQuery();
    
                    CamlQuery camlQuery = new CamlQuery();
                    camlQuery.ViewXml = @"<View Scope='Recursive'>
                                         <Query>
                                         </Query>
                                     </View>";
                    camlQuery.FolderServerRelativeUrl = folder.ServerRelativeUrl;
                    ListItemCollection listItems = list.GetItems(camlQuery);
                    clientContext.Load(listItems);
                    clientContext.ExecuteQuery();
                    foreach(var item in listItems)
                    {
                        var file = item.File;
                        clientContext.Load(file);
                        clientContext.ExecuteQuery();
                        if (file != null)
                        {
                            Console.WriteLine(file.Name);
                        }
                    }
                }
                Console.ReadKey();
