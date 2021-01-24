csharp
public class MyInt
{
    public int RngProp { get; set; }
}
public class Entity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonSerializer(typeof(RngSerializer))]
    public MyInt MyProp { get; set; } = new MyInt();
}
public class RngSerializer : SerializerBase<MyInt>
{
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, MyInt value)
    {
        var rnd = new Random().Next(0, 100);
        value.RngProp = rnd;
        Console.WriteLine($"written rng {rnd}");
        context.Writer.WriteInt32(rnd);
    }
    public override MyInt Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        return new MyInt
        {
            RngProp = context.Reader.ReadInt32()
        };
    }
}
var entity = new Entity();
collection.InsertOne(entity);
Console.WriteLine($"Inserted Id {entity.Id}, Rng {entity.MyProp.RngProp}");
var result = collection.FindSync(e => e.Id == entity.Id).Single();
Console.WriteLine($"Retrieved Id {entity.Id}, Rng {result.MyProp.RngProp}");
Console.ReadLine();
