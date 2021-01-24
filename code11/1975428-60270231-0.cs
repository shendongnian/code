    public class RngSerializer : SerializerBase<int>
    {
        #region Overrides of SerializerBase<int>
        public override int Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return context.Reader.ReadInt32();
        }
        #endregion
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, int value)
        {
            //This part is important otherwise it will call the rng twice, once when the ToBson() is called and once when inserting.
            if (value == 0)
            {
                var rng = new Random().Next(0, 100);
                Console.WriteLine($"Generated rng {rng}");
                context.Writer.WriteInt32(rng);
            }
            else
            {
                context.Writer.WriteInt32(value);
            }
        }
    }
