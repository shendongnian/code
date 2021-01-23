    // important: declare the input parameter to be an **array** of T, not T.
    static void SerializeObject<T>(T[] obj) where T : class
    {
        string fileName = Guid.NewGuid().ToString().Replace("-", "") + ".xml";
        using (FileStream fs = File.Create(fileName))
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
    
            // override default root node name.  based on your question, 
            // i'm just going to append an "s" to the base type 
            // (e.g., Person becomes Persons)
            var rootName = typeof(T).Name + "s";
            XmlRootAttribute root = new XmlRootAttribute(rootName);
            
            // add the attribute to the serializer constructor...
            XmlSerializer ser = new XmlSerializer(obj.GetType(), root);
    
            ser.Serialize(fs, obj, ns);
        }
    }
Secondly, in the Main() method, replace SerializeObject<Person[]>(p) with SerializeObject<Person>(p).  Thus your Main() method will look like this:
    static void Main(string[] args)
    {
        Person[] p = 
        {
            new Person{Age = 20, Firstname = "Michael", Lastname = "Jackson"},
            new Person{Age = 21, Firstname = "Bill", Lastname = "Gates"},
            new Person{Age = 22, Firstname = "Steve", Lastname = "Jobs"}
        };
    
        SerializeObject<Person>(p);
    }
