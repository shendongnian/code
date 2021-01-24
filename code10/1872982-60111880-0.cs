    public class MyClass {
    public ObjectId Id { get; set; }
    [BsonSerializer(typeof(MyCustomStringSerializer))]
    public string X { get; set; }
    }
    BsonClassMap.RegisterClassMap<MyClass>(cm => {
    cm.AutoMap();
    cm.GetMemberMap(c => c.X).SetSerializer(new MyCustomStringSerializer());
    });
