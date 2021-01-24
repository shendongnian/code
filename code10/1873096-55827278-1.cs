    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(@"put html string here");
    var listOfUrls = new List<string>();
    doc.DocumentNode.SelectNodes("//a").ToList()
       .ForEach(x=> 
               {
                  //Use HasClass method to filter elements 
                  if (!string.IsNullOrEmpty(x.GetAttributeValue("href", "")) 
                       && x.HasClass("result-title") && x.HasClass("js-result-title"))
                  {
                     listOfUrls.Add(x.GetAttributeValue("href", ""));
                  }
               });
    listOfUrls.ForEach(x => Console.WriteLine(x));
