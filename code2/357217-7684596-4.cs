    [Serializable]
    public class Patient
    {
        public string Name {get; set;}
        public int Age {get; set;}
        public int Id {get; set;}
        public override string ToString()
        {
             return Name;
        }
    }
    ...
    public void Serialize(List<Patient> pList)
    {
        using (Stream writer = new FileStream(filename, FileMode.Create))
        {
            var serializer = new XmlSerializer(typeof (List<Patient>));
            serializer.Serialize(writer, pList);
        }
    }
    public List<Patient> Deserialize()
    {
        using (Stream reader = new FileStream(filename, FileMode.Open))
        {
            var serializer = new XmlSerializer(typeof (List<Patient>));
            var pList = (List<Patient>) serializer.Deserialize(reader);
            return pList;
        }
    }
