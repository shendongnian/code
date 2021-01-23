    // untested
    var masterDoc = XDocument.Load(...);
    var updateDoc = XDocument.Load(...);
    
    foreach (var year in updateDoc.Root.Descendants("FiscalYear"))
    {
        var oldYear = masterDoc.Root.Descendants("FiscalYear")
                  .Where(y => y.Attributes["ID"].Value == year.Attributes["ID"].Value)
                  .FirstOrDefault() ;
        if (oldYear == null)
        {
             masterDoc.Root.Add(new XElement(....));
        }
        else
        {
            // nested properties
        }
    }
