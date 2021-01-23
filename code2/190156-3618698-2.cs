     SerializeObject<Person[]>(p, per=>p.GetType().Name);
    static void SerializeObject<T>(T obj, Func<T,string> nameSelector) where T : class
    {
        string fileName = Guid.NewGuid().ToString().Replace("-", "") + ".xml";
        using (FileStream fs = File.Create(fileName))
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlRootAttribute root = new XmlRootAttribute(nameSelector(obj));
            XmlSerializer
              ser = new XmlSerializer(typeof(Person[]), root);
            ser.Serialize(fs, obj, ns);
        }
    }
