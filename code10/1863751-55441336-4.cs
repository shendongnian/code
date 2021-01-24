    //Parse you json to JObject.
    JObject jObject = JObject.Parse(json);
    
    //Cast your JObject to your class models
    RootObject resReturnListData = jObject.ToObject<RootObject>();
    
    //By using LINQ make group by with key firstName
    var newResult = resReturnListData.returned_data.data
        .GroupBy(x => x.firstName)
        .Select(g => new
        {
            firstName = g.Key,
            lastName = g.Select(x => x.lastName).FirstOrDefault(),
            product = g.SelectMany(x => x.product).ToList()
        }).ToList();
    
    
    //Or make group by on keys firstName and lastName
    var newResult = resReturnListData.returned_data.data
        .GroupBy(x => new { x.firstName, x.lastName })
        .Select(g => new
        {
            firstName = g.Key.firstName,
            lastName = g.Key.lastName,
            product = g.SelectMany(x => x.product).ToList()
        }).ToList();
    
    //Assign above new result to again specific key
    jObject["returned_data"]["data"] = JToken.FromObject(newResult);
    
    //Finally retrieve json string
    string newJson = jObject.ToString();
    
    //Print you new json
    Console.WriteLine(newJson);
    Console.ReadLine();
