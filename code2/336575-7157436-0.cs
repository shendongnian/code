    XmlDocument xml = new XmlDocument();
    xml.LoadXml(System.Web.HttpContext.Current.Server.MapPath("XmlFile.xml")); 
    
    XmlNodeList xnList = xml.SelectNodes("/StudentList/student");
    foreach (XmlNode xn in xnList)
    {
      string name= xn["name"].InnerText;
      string Id= xn["Id"].InnerText;   
    }
