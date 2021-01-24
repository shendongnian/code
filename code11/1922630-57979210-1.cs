    XDocument xDocument = XDocument.Parse("<Feedback><Officer>Officer</Officer><Answers>My text</Answers><Date>20190917</Date></Feedback>");
    XDocument newDoc = new XDocument();
    XElement rootElement = new XElement("feedback");
    newDoc.Add(rootElement);
    
    foreach (var node in xDocument.Root.Elements())
       {
          newDoc.Root.Add(node);
       }
    
    Console.WriteLine(newDoc);
    Console.ReadLine();
