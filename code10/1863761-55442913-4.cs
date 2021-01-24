    var resReturnListData = JsonConvert.DeserializeObject<RootObject>(jsonString);
    var newResult = resReturnListData.returned_data.data
                    .GroupBy(x => x.firstName)
                    .Select(x => new Datum
                    {
                        firstName = x.Key,
                        lastName = x.Select(c => c.lastName).FirstOrDefault(),
                        product = x.SelectMany(c => c.product).ToList()
    
                    });
    
    var finalObject = new RootObject
    {
        returned_data = new ReturnedData
        {
            data = newResult.ToList()
        }
    };
    var jsonResult = JsonConvert.SerializeObject(finalObject,Newtonsoft.Json.Formatting.Indented);
