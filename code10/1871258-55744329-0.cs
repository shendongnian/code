    JObject jObject = JObject.Parse(firebaseResponse.Body);
    
    JObject outputObj = new JObject();
    
    foreach (var prop in jObject.Properties())
    {
        outputObj[prop.Name] = JObject.FromObject(new
        {
            AutoId = prop.Name,
            CustomerId = outputObj["CustomerId"],
            DateTime = outputObj["DateTime"],
            Id = outputObj["Id"],
            OrderId = outputObj["OrderId"]
        });
    }
    
    Console.WriteLine(outputObj);
