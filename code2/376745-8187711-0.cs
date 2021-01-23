 	ISettings Settings { get; set; }
    }
    public interface ISettings : ISerializable
    {
        DateTime StartDate { get; }
    }
    public class SerializeHelper<T>
    {
        public static void Serialize(string path, T item)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (TextWriter textWriter = new StreamWriter(path, false, Encoding.UTF8))
            {
                serializer.Serialize(textWriter, T item);
            }
        }
    }
     
    SerializeHelper.Serialize(@"%temp%\sample.xml", instanceOfISomeInterface);
