        var result = await client.GetItemAsync("persontable", new Dictionary<string, AttributeValue>
        {
            {  "PK", new AttributeValue { S = "MYID123" } }
        });
        var person = new Person
        {
            Id = result.Item["PK"].S,
            Name = result.Item["Name"].S,
            OtherAttributes = new Dictionary<string, string>()
        };
        foreach (var attribute in result.Item)
        {
            if (attribute.Key != "PK" && attribute.Key != "Name")
            {
                person.OtherAttributes.Add(attribute.Key, attribute.Value.S); // This code is handling only the case when attirubutes are on the top level and has string type. For more complex scenarios it should be extended additionally. 
            }
        }
