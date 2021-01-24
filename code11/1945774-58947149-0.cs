     using System.IO;
    using System.Xml.Serialization;
    namespace YourProject
    {
    public class XMLParser<T> where T : class
    {
     
        public static T Deserialize(string path)
        {
            T item;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                using (var reader = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    item = (T)serializer.Deserialize(reader);
                    reader.Dispose();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            return item;
        }
     
        public static void Serialize(object item, string path)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (var writer = new StreamWriter(fs))
                {
                    serializer.Serialize(writer, item);
                    writer.Close();
                    writer.Dispose();
                }
            }
        }
    }
    }
