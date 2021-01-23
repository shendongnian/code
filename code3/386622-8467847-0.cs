    [Serializable]
    public class Pets
    {
        public int Cats { get; set; }
        public int Dogs { get; set; }
    }
    
    public static class Utils
    {
        public static byte[] BinarySerialize(object o)
        {
            using (var ms = new MemoryStream())
            {
                IFormatter f = new BinaryFormatter();
                f.Serialize(ms, o);
                return ms.ToArray();
            }
        }
    
        public static dynamic BinaryDeserialize(byte[] bytes, dynamic o)
        {
            using (var ms = new MemoryStream(bytes))
            {
                ms.Position = 0;
                IFormatter f = new BinaryFormatter();
                o = (dynamic)f.Deserialize(ms);
                return o;
            }
        }
    }
