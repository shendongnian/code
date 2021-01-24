    var folderItem = new ListItem
    {
        ContentType = new ContentTypeInfo()
           {
               Id = "0x0120"
           },
           Fields = new FieldValueSet()
                   {
                        AdditionalData = new Dictionary<string,object>
                        {
                            {
                                "Title", folderName
                            }
                        }
                    }
    };
    await graphClient
           .Sites.Root
           .Lists["<list name or id>"]
           .Items
           .Request()
           .AddAsync(folderItem);
