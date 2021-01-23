    XDocument doc = new XDocument(
        new XDeclaration("1.0", "utf-8", "yes"),
        new XComment("Example"),
    new XElement("Commentarys",
            new XElement("Commentary",
                new XAttribute("page", "2"),
                new XAttribute("businessName", "name"),
                new XElement("Commentator",
                   new XAttribute("name", "name"),
                    new XAttribute("title", "title")
                )
             )
            ,
            new XElement("Commentary",
                new XAttribute("page", "3"),
                new XAttribute("businessName", "name2")
            
                )
        )
        );
    var genericOfflineFactsheet = new
    {
        Commentary = (
               from commentary in doc.Elements()
                    .First().Elements("Commentary")
               select new
              {
                  CommentaryPage = (string)commentary.Attribute("page"),
                  BusinessName = (string)commentary.Attribute("businessName"),
                  Commentator = (from commentator in commentary.Elements("Commentator")
                                 where commentator != null //<-----you need to add this line
                                 select new // ASP.NET UserControl
                                 {
                                     CommentatorName = (string)commentator.Attribute("name"),
                                     CommentatorTitle = (string)commentator.Attribute("title"),
                                     CommentatorCompany = (string)commentator.Attribute("company")
                                 }
                                
                                 ).FirstOrDefault()
              }
     ).FirstOrDefault()
    };
    
