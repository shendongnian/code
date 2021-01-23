    var doc = new XmlDocument();
    doc.LoadXml(@"<?xml version=""1.0""?>
          <root xmlns:my=""http://schemas.microsoft.com/office/infopath/2003/myXSD/2010-11-30T17:39:37"" value=""1"">
               <my:item>test</my:item>
          </root>");
    var nameTable = new NameTable();
    var namespaceManager = new XmlNamespaceManager(nameTable);
    namespaceManager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
    namespaceManager.AddNamespace("xhtml", "http://www.w3.org/1999/xhtml");
    namespaceManager.AddNamespace("dfs", "http://schemas.microsoft.com/office/infopath/2003/dataFormSolution");            
    namespaceManager.AddNamespace("my", "http://schemas.microsoft.com/office/infopath/2003/myXSD/2010-07-14T13:45:59");
    namespaceManager.AddNamespace("xd", "http://schemas.microsoft.com/office/infopath/2003");
    // n will be null since the namespace url doesn't match
    var n = doc.SelectSingleNode("descendant::my:item", namespaceManager);
    namespaceManager.PushScope();
    namespaceManager.AddNamespace("my", "http://schemas.microsoft.com/office/infopath/2003/myXSD/2010-11-30T17:39:37");
    // will work
    n = doc.SelectSingleNode("descendant::my:item", namespaceManager);
    namespaceManager.PopScope();
