    using System.Xml;
    using System.Xml.XPath;
    ....
    string fileName = "test.xml";
    XPathDocument doc = new XPathDocument(fileName);
    XPathNavigator nav = doc.CreateNavigator();
    
    // Compile a standard XPath expression
    
    XPathExpression expr; 
    idExpr = nav.Compile("/content/CatalogItems/CatalogItem/@id");
    XPathNodeIterator iterator = nav.Select(idExpr);
    // Iterate on the node set
    try
    {
      while (iterator.MoveNext())
      {
         XPathNavigator nav2 = iterator.Current.Clone();
         Console.WriteLine("id: " + nav2.Value);
      }
    }
    catch(Exception ex) 
    {
       Console.WriteLine(ex.Message);
    }
