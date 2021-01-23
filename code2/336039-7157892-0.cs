    public interface IBinarySerializable
    {
        void Serialize(BinaryWriter writer);
        void Deserialize(BinaryReader reader);
    }
    public static class BinaryReaderWriterExtensions
    {
        public static void Write(this BinaryWriter writer, IBinarySerializable value)
        {
            value.Serialize(writer);
        }
        public static T Read<T>(this BinaryReader reader)
            where T : IBinarySerializable, new()
        {
            var val = new T();
            val.Deserialize(reader);
            return val;
        }
        public static void ReadInto(this BinaryReader reader, IBinarySerializable value)
        {
            value.Deserialize(reader);
        }
        public static void WriteList<T>(this BinaryWriter writer, IList<T> list, Action<BinaryWriter, T> singleValueWriter)
        {
            writer.Write(list.Count);
            foreach (var item in list)
                singleValueWriter(writer, item);
        }
        public static IEnumerable<T> ReadList<T>(this BinaryReader reader, Func<BinaryReader, T> singleValueReader)
        {
            var ct = reader.ReadInt32();
            for (var i = 0; i < ct; i++)
                yield return singleValueReader(reader);
        }
    }
    public class WantsToBeSerialized : IBinarySerializable
    {
        public int ID;
        public string CustomerName;
        public List<string> Nicknames;
        public SomeOtherSerializableObject Thing;
        void IBinarySerializable.Serialize(BinaryWriter writer)
        {
            writer.Write(ID);
            writer.Write(CustomerName);
            writer.WriteList(Nicknames, (w, value) => w.Write(value));
            writer.Write(Thing);
        }
        void IBinarySerializable.Deserialize(BinaryReader reader)
        {
            ID = reader.ReadInt32();
            CustomerName = reader.ReadString();
            Nicknames = new List<string>(reader.ReadList(x => x.ReadString()));
            Thing = reader.Read<SomeOtherSerializableObject>();
        }
    }
