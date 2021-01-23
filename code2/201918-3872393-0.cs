    XElement element = 
        new XElement("PublishedPages",
            (from page in publishedPages 
                 select new XElement("PublishedPage",
                     new XElement("Action", page.Action),
                     new XElement("PageGuid",page.PageGuid),
                     new XElement("SearchableProperties",
                         (from property in page.SearchableProperties
                          select new XElement("Name",property)))
                          )
             )
         );
