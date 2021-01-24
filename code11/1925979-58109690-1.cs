    var document = XDocument.Load(path);
    var products = document.Descendants("product")
        .Where(product => product.Descendants("subcategory")
                                 .Any(sub => sub.Attributes("id")
                                                  .Any(id => id.Value == "SUB1000")));
    foreach(var product in products)
    {
        var subId = product.Attributes("id").Select(id => id.Value).FirstOrDefault();
        
        Console.WriteLine($"Product: {subId}");
    }        
