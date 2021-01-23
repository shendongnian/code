    function GetListData(String SiteURL, string DocLibName, string ListId)
    com.mysite.Lists lists = new Lists()
    {
    
    lists.Credentials = new System.Net.NetworkCredential(user, pwd, "CORP");
    
    lists.Url = SiteURL +/_vti_bin/Lists.asmx";
    XmlNode ndQuery = xmlDoc.CreateNode(XmlNodeType.Element, "Query", "");
    XmlNode ndViewFields = xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields", "");
    XmlNode ndQueryOptions = xmlDoc.CreateNode(XmlNodeType.Element, "QueryOptions", "");
    
    XmlNode listitems = lists.GetListItems(DocLibName, null, ndQuery, ndViewFields, "1000",
                                                   ndQueryOptions, null);
    
    }
