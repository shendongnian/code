    void Main()
    {
        var xDoc = XDocument.Parse(@"<?xml version=""1.0""?>
    <catalog>
       <book id=""bk101"">
          <author>Gambardella, Matthew</author>
          <title>XML Developer's Guide</title>
          <genre>Computer</genre>
          <price>44.95</price>
          <publish_date>2000-10-01</publish_date>
          <description>An in-depth look at creating applications with XML.</description>
       </book>
    </catalog>", LoadOptions.PreserveWhitespace);
    
        XElement Author = xDoc.Root.Descendants("author").FirstOrDefault();
        XElement Title = xDoc.Root.Descendants("title").FirstOrDefault();
        XElement Genre = xDoc.Root.Descendants("genre").FirstOrDefault();
    
        // Do something with Author, Title, and Genre here...
    
        if (Author != null) Author.RemoveWithNextWhitespace();
        if (Title != null) Title.RemoveWithNextWhitespace();
        if (Genre != null) Genre.RemoveWithNextWhitespace();
    
        xDoc.ToString().Dump();
    }
    
    static class Ext
    {
        public static void RemoveWithNextWhitespace(this XElement element)
        {
            if (element.PreviousNode is XText textNode)
            {
                textNode.Remove();
            }
            
            element
            .Remove();
        }
    }
