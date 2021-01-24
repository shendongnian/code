    JsonSerializer serializer = new JsonSerializer()
    {
        TypeNameHandling = TypeNameHandling.None,  // make it ignore type handling for now
    };
    var dyn = serializer.Deserialize<dynamic>(reader);   // to a dynamic object
    var str = (string)JsonConvert.SerializeObject(dyn);  // convert to JSON
    // search and replace the old name space / assembly with the new
    str = str.Replace("MyNameSpace.Foo, MyFirstAssembly",
              $"{typeof(Foo).FullName}, {typeof(Foo).Assembly.GetName().Name}");
    // convert back to a dynamic object
    dyn = JsonConvert.DeserializeObject<dynamic>(str);
    var ms2 = new MemoryStream();
    using (BsonWriter writer = new BsonWriter(ms2))
    {
        // write it back to BSON
        serializer.Serialize(writer, dyn);
        // at this point we'd update the database record,
        // but to confirm we can now deserialize the updated data...
        ms2.Position = 0;
        using (var reader2 = new BsonReader(ms2))
        {
            // turn type handling back on
            serializer.TypeNameHandling = TypeNameHandling.All;
            tempResponse = serializer.Deserialize<MyClass>(reader2);  // success!
        }
    }
