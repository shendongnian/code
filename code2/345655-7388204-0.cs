    // untested
    var masterDoc = XDocument.Load(...);
    var updateDoc = XDocument.Load(...);
    
    foreach (var year in updateDoc.Root.Descendants("FiscalYear"))
    {
        var oldYear = masterDoc.Root.Descendants("FiscalYear").FirstOrDefault() ;
        if (oldYear == null)
        {
             masterDoc.Root.Add(new XElement(....));
        }
        else
        {
            // nested properties
        }
    }
