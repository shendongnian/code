    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Garage));
            var garage = new Garage
            {
                Owner = new Owner { Name = "Daniel" },
                Cars = new List<string>
                {
                    "ABC123",
                    "DSC563",
                    "AIO789",
                    "IUE692",
                }
            };
            serializer.Serialize(File.Create("file.xml"), garage);
        }
    }
    [Serializable]
    public class Garage
    {
        [XmlElement("Owner")]
        public Owner Owner;
        [XmlArrayItem("Plate")]
        public List<string> Cars;
    }
    [Serializable]
    public class Owner
    {
        [XmlElement("Name")]
        public string Name;
    }
