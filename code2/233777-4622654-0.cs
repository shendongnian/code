    namespace IsolatedStorageSerialization
    {
        using System;
        using System.IO;
        using System.IO.IsolatedStorage;
        using System.Xml;
        using System.Xml.Serialization;
    
        internal static class Program
        {
            private static void Main()
            {
                object thisIsAnObject = new object();
    
                SerializeToIsolatedStorage(thisIsAnObject, "object.xml");
    
                object anotherObject = DeserializeFromIsolatedStorage<object>("object.xml");
    
                Console.ReadLine();
            }
    
            private static void SerializeToIsolatedStorage<T>(T obj, string filename)
            {
                if ((obj == null) || string.IsNullOrEmpty(filename))
                {
                    return;
                }
    
                using (var store = IsolatedStorageFile.GetUserStoreForAssembly())
                using (var stream = store.CreateFile(filename))
                using (var writer = XmlWriter.Create(stream))
                {
                    new XmlSerializer(obj.GetType()).Serialize(writer, obj);
                }
            }
    
            private static T DeserializeFromIsolatedStorage<T>(string filename)
            {
                if (string.IsNullOrEmpty(filename))
                {
                    return default(T);
                }
    
                using (var store = IsolatedStorageFile.GetUserStoreForAssembly())
                using (var stream = store.OpenFile(filename, FileMode.Open))
                using (var reader = XmlReader.Create(stream))
                {
                    return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                }
            }
        }
    }
