    App.ClientSpecsList.Lists listService = new App.ClientSpecsList.Lists();
    listService.Url = "http://sp2013/sites/team/_vti_bin/Lists.asmx";
    listService.Credentials = new System.Net.NetworkCredential("username", "password", "domainname");
    System.Xml.XmlNode ndListView = listService.GetListAndView("Client Specs", "");
    string strListID = ndListView.ChildNodes[0].Attributes["Name"].Value;
    string strViewID = ndListView.ChildNodes[1].Attributes["Name"].Value;
