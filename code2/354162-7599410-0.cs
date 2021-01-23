    dynamic propertyMap = new ExpandoObject();
    var item = propertyMap as IDictionary<String, object>;
    
    item["A"] = DateTime.Now;
    item["B"] = "New val 2";
    propertyMap.C = 1234
    
    Console.WriteLine(propertyMap.A);
    Console.WriteLine(propertyMap.B);    
    Console.WriteLine(propertyMap.C);
