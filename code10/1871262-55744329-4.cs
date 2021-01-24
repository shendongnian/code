    JObject jObject = JObject.Parse(firebaseResponse.Body);
       
    foreach (var prop in jObject.Properties())
    {
        jObject[prop.Name] = JObject.FromObject(new
        {
            AutoId = prop.Name,                       //<= Child object name here
            CustomerId = prop.Value["CustomerId"],    //<= Remaining properties as it is
            DateTime = prop.Value["DateTime"],
            Id = prop.Value["Id"],
            OrderId = prop.Value["OrderId"]
        });
    }
    
    string outputJson = jObject.ToString();
    
    
