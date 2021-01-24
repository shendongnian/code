    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(@"put html string here");
    var listOfUrls = new List<string>();
    doc.DocumentNode.SelectNodes("//a").ToList()
       .ForEach(x=> 
               {
                  if (!string.IsNullOrEmpty(x.GetAttributeValue("href", "")))
                  {
                     listOfUrls.Add(x.GetAttributeValue("href", ""));
                  }
               });
    listOfUrls.ForEach(x => Console.WriteLine(x));
