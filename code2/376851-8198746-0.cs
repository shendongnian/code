    public void SaveInDB(IdbCommand argCommand,String argFileName)
    {
      using(FileStream fs = new FileStream(argFileName, FileMode.Open, FileAccess.Read))
      {
        XmlDocument doc = new XmlDocument();
        doc.Load(fs);
        XmlNamespaceManager ns = new XmlNameSpaceManager(doc.NameTable);
        ns.Add("os",doc.DocumentElement.NamespaceUri);
        foreach(XmlNode catNode in doc.DocumentElement.SelectNodes("os:cat",ns))
        {
           argCommand.Parameters["ID"].Value = catNode.Attributes["id"].Value; // convert to an int?
           argCommand.Parameters["os_lev"].Value = catNode.LocalName;
           argCommand.Parameters["title"].Value = catNode.Attributes["name"].Value;
           argCommand.Parameters["parent_id"].Value = DBnull;
           argCommand.Parameters["cut_url"].Value = DBNull;
           argCommand.ExecuteNonQuery();
           foreach(XMlNode subcatNode in catNode.SelectNodes("os:subcat",ns)
           {
             SaveSubcatInDB(argCommand,subcatNode,ns);
           } 
        }
      }
    }
    private static void SaveSubcatInDB(IdbCommand argCommand, XmlNode argNode, XmlNameSpaceManager argNs)
    {
      // you get the idea.
    }
