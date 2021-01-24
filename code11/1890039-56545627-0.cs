    var queryOptions = new List<QueryOption>()
                    {
                        new QueryOption("expand", "fields(select=id,Title)")
                    };
    
    
    
                    var items = await graphServiceClient.Sites["emrisdev.sharepoint.com"].Lists["TeamsRequest"].Items
                         .Request(queryOptions)
                         .GetAsync();
    
    
    
    
                    foreach (var item in items)
                    {
                        Console.WriteLine(item.Fields.AdditionalData["Title"]);
                        Console.WriteLine("Name:" + item.Name);
                        Console.WriteLine($"ID: {item.Id}");
                    }
