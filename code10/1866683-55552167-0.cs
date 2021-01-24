    XDocument xdoc = XDocument.Load(@"Path to your xml file");
    
    var result = (from car in xdoc.Descendants("Car")
                  select new
                  {
                      StockNumber = car.Element("StockNumber")?.Value,
                      Make = car.Element("Make")?.Value,
                      Model = car.Element("Model")?.Value
                  }).ToList();
    
    
    Console.WriteLine("StockNumber\tMake\t\tModel");
    Console.WriteLine("----------------------------------------------");
    foreach (var item in result)
    {
        Console.WriteLine(item.StockNumber + "\t\t" + item.Make + "\t\t" + item.Model); ;
    }
