        XmlDocument XmlDoc = new XmlDocument();
        XmlDoc.Load(Server.MapPath("~/Upload/" + FileUpload1.FileName));
        string searchpath = "//root//row";
        XmlNodeList xmlnodes = XmlDoc.SelectNodes(searchpath);
        foreach (XmlNode node in xmlnodes)
        {
             string name = node.SelectSingleNode("//var[@name='Name']").Attributes["value"].InnerXml;
             string surname = node.SelectSingleNode("//var[@name=' Surname']").Attributes["value"].InnerXml;
             string Country = node.SelectSingleNode("//var[@name=' Country']").Attributes["value"].InnerXml;
             string Job = node.SelectSingleNode("//var[@name=' Job']").Attributes["value"].InnerXml;
             string Cabin = node.SelectSingleNode("//var[@name=' Cabin']").Attributes["value"].InnerXml;
        }
