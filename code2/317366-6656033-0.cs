    using System.IO;
    using ProtoBuf;
    public static class AltSerialization
    {
        public static byte[] AltSerialize(Measurement m)
        {
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, m);
                return ms.ToArray();
            }
        }
    
        public static Measurement AltDeSerialize(byte[] seriM)
        {
            using (var stream = new MemoryStream(seriM))
            {
                return Serializer.Deserialize<Measurement>(stream);
            }
        }
    }
    
    [ProtoContract]
    public class Measurement
    {
        public int id; // not serialized
        [ProtoMember(1)]
        public int time; // serialized as field 1
        [ProtoMember(2)]
        public double value; // serialized as field 2
    
        public Measurement()
        {
            id = 1;
            time = 12;
            value = 0.01;
        }
        public Measurement(int _id, int _time, double _value)
        {
            id = _id;
            time = _time;
            value = _value;
        }
    }
