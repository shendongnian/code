    [Serializable]
    public class Patient
    {
        public string Name {get; set;}
        public int Age {get; set;}
        public int Id {get; set;}
    }
    ...
    public void Serialize(Patient pObj)
    {
        using (Stream writer = new FileStream(filename, FileMode.Create)
        {
              var serializer = new XmlSerializer(typeof(Patient));
              serializer.Serialize(writer, pObj);
        }
    }
    
    public Patient Deserialize()
    {
        using (Stream reader = new FileStream(filename, FileMode.Open))
        {
            var serializer = new XmlSerializer(typeof(Patient));
            var pObj = (Patient) serializer.Deserialize(reader);
            return pObj;
        }
    }
