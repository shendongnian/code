    var options = new CreateCollectionOptions<Entity>
    {
        ValidationAction = DocumentValidationAction.Error,
        ValidationLevel = DocumentValidationLevel.Strict,
        Validator = new FilterDefinitionBuilder<Entity>()
        .And(
            new FilterDefinitionBuilder<Entity>().JsonSchema(new BsonDocument
        {
            { "bsonType", "object" },
            { "properties", new BsonDocument("Items", new BsonDocument
                {
                    { "type" , "array" },
                    { "uniqueItems", true }
                })
            }
        })
        )
    };
    database.CreateCollection("entities", options, CancellationToken.None);
