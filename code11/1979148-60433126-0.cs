    var productName = "name2";
    
    var xdoc = XDocument.Load(fileName);
    var nodes = xdoc.Descendants("Product")
                    .Where(x => (string)x.Attribute("name") == productName)
                    .Select(x => x);
    
    Console.WriteLine($"For {productName}:");
    foreach (var value in nodes.Elements())
    {
        Console.WriteLine($"{value.Name} = {value.Value.ToString()}");
    }
