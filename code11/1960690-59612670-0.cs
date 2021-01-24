    await client.IndexManyAsync(new []
    {
        new Document{Id = "1", Name = "name1"}, 
        new Document{Id = "2"}, 
        new Document{Id = "3"}, 
        new Document{Id = "4"}, 
        new Document{Id = "5"}
    });
    
    await client.Indices.RefreshAsync();
    
    var getResponse = await client.GetAsync<Document>("1");
    
    System.Console.WriteLine($"Id: {getResponse.Source.Id} Name: {getResponse.Source.Name}");
