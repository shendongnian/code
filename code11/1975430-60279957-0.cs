csharp
    public class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
                
        [BsonSerializer(typeof(RngSerializer))]
        public int RngProp { get; set; } = new Random().Next(0, 100);
    } 
csharp
    public class RngSerializer : SerializerBase<int>
    {
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, int value)
        {
            Console.WriteLine($"written rng {value}");
            context.Writer.WriteInt32(value);
        }
        public override int Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return context.Reader.ReadInt32();
        }
    }
csharp
    var entity = new Entity();
    collection.InsertOne(entity);
    Console.WriteLine($"Inserted Id {entity.Id}, Rng {entity.RngProp}");
    var result = collection.FindSync(e => e.Id == entity.Id).Single();
    Console.WriteLine($"Retrieved Id {entity.Id}, Rng {result.RngProp}");
    Console.ReadLine();
