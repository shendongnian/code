    XElement saveButtonXe = 
            ((IEnumerable)doc.
              XPathEvaluate("//def:Canvas/basics:Button[@x:Name = 'Save']", nsm))
              .Cast<XElement>()
              .SingleOrDefault();
    
    if(saveButtonXe != null)
    {
      // Set the Width value
      saveButtonXe.Attribute("Width").SetValue("250");
      Console.WriteLine(doc.ToString());
    }
