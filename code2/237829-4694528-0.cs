    ClientContext clientContext = new ClientContext("http://sp2010Server/sites/mySite");
    SP.List oList = clientContext.Web.Lists.GetByTitle("Site Requests");
    
    ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
    ListItem oListItem = oList.AddItem(itemCreateInfo);
    oListItem["Title"] = "title";
    oListItem["Description"] = "description";
    oListItem["Url"] = "someUrl";
    
    oListItem.Update();
    
    clientContext.ExecuteQuery(); 
