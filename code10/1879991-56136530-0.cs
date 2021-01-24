    string siteUrl = "http://servername Jump :2525/";
    ClientContext clientContext = new ClientContext(siteUrl);
    List oList = clientContext.Web.Lists.GetByTitle("DemoList");
    ListItemCreationInformation listCreationInformation = new ListItemCreationInformation();
    ListItem oListItem = oList.AddItem(listCreationInformation);
    oListItem["Title"] = "Add item in SharePoint List using CSOM";
    oListItem.Update();
    clientContext.ExecuteQuery();
