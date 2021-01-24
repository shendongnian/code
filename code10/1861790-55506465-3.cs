            // serializer
            var serializerRegistry = BsonSerializer.SerializerRegistry;
            var documentSerializer = serializerRegistry.GetSerializer<T>();
            // filter and update
            var filter = Builders<T>.Filter.Eq(e => e.Level, 2);
            var updates = Builders<T>.Update
                         .Set(e => e.Name, "foo2")
                         .Set(e => e.Path, "foo2 path")
                         .Inc(e => e.Level, 1);
            // get the string of the filter and the update
            var filterString = filter.Render(documentSerializer, serializerRegistry);
            var updateString = updates.Render(documentSerializer, serializerRegistry);
            // instantiate patch object with properties to json
            Patch patch = new Patch()
            {
                Query = filterString.ToJson(),
                Update = updateString.ToJson()
            };
            // patch object to json
            var patchJson = patch.ToJson();
