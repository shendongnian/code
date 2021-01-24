     using(var clientContext =new ClientContext("http://sp"))
                {
                    var web = clientContext .Web;
                    var oList = web.Lists.GetByTitle("TestDetails");
    
                    ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                    ListItem oListItem = oList.AddItem(itemCreateInfo);
                    FieldLookupValue lookupField = new FieldLookupValue();
                    lookupField.LookupId = 1;
                    oListItem["Title"] = "My New Item!";
                    oListItem["Name"] = lookupField;
                    oListItem.Update();
                    clientContext.ExecuteQuery();
    
                    Console.WriteLine("complete");
                }
