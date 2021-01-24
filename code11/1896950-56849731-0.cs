    ClientContextctx = newClientContext("http://gowtham.sharepoint.com");  
                List oList = ctx.Web.Lists.GetByTitle("Announcements");  
                ListItemCreationInformationitemCreateInfo = newListItemCreationInformation();  
                ListItemnewItem = oList.AddItem(itemCreateInfo);  
                newItem["Title"] = "Test Item!";  
                newItem["Body"] = "welcome to Gowtham Blog";  
                newItem.Update();
                context.ExecuteQuery();  
