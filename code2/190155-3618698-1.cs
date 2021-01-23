     static void SerializeObject<T>(T obj) where T : class
        {
            string fileName = Guid.NewGuid().ToString().Replace("-", "") + ".xml";
            using (FileStream fs = File.Create(fileName)) 
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                XmlRootAttribute root = new XmlRootAttribute( typeof(T).Name + "s");
                XmlSerializer
                  ser = new XmlSerializer(typeof(Person[]), root);
                  ser.Serialize(fs, obj, ns);
            }
        }
