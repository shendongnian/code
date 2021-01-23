    [Serializable]
    public class Name
    {
        public Name()
        {
            Num=new List<int>();
        }
        [XmlAttribute("Name")]
        public string Name{get;set;}
        [XmlArray("Num")]
        public List<int> Num{get;set;}
    }
