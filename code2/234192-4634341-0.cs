    public class Elems
    {
        [XmlArray("how")]
        [XmlArrayItem("testing")]
        public List<Test> How { get; set; }
    
        public Elems()
        {
            how = new List<Test>();
            how.Add(new Test());
            how.Add(new Test());
            how.Add(new Test());
        }
    }
