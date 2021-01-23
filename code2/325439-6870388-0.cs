    public string GetDestination(string categoryName, XDocument xDoc)
    {
    
         var query = (from x in xDoc.Descendants("DocumetentCategory")
                      where ((string)x.Element("CategoryName")).Contains(categoryName)
                      select (string)x.Element("DestinationDocumentLibrary")).SingleOrDefault();
          
         return (string)query;
    }
