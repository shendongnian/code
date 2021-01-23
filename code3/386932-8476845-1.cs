     var htmlDoc = new HtmlDocument();
     htmlDoc.Load("test.txt");
     var items = from li in htmlDoc.DocumentNode.Descendants("li")
                 from b in li.Descendants("b")
                 from a in li.Descendants("a")
                 where a.Attributes["title"] != null && 
                 a.Attributes["title"].Value.StartsWith("Program")
                 select new
                 {
                   Name = a.InnerText,
                   Category = b.InnerText
                 };
    
     foreach (var item in items)
     {
       Console.WriteLine("{0}: {1}", item.Category, item.Name);
     }
     Console.ReadKey();
