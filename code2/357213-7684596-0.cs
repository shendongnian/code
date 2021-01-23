    [Serializable]
    public class Patient
    {
        public string Name {get; set;}
        public int Age {get; set;}
        public int Id {get; set;}
    }
    ...
    public void Serialize()
    {
        using (Stream writer = new FileStream(filename, FileMode.Create)
        {
              var pObj = new Patient() { Age = 30 };
              XmlSerializer serializer = new XmlSerializer(typeof(Patient));
              serializer.Serialize(writer, pObj);
        }
    }
