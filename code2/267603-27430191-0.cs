    string release = OClient.CreateDatabasePool("127.0.0.1", 2424, "ModelTestDB", ODatabaseType.Graph, "admin", "admin", 10, "ModelTestDBAlias");
    using(ODatabase database = new ODatabase("ModelTestDBAlias"))
    {
        // prerequisites
        database
          .Create.Class("TestClass")
          .Extends<OVertex>()
          .Run();
        OVertex createdVertex = database
          .Create.Vertex("TestClass")
          .Set("foo", "foo string value")
          .Set("bar", 12345)
          .Run();
    }
