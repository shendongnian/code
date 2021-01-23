    public class Person
    {
        public string Name
        {
            get;
            set;
        }
    
        [XmlIgnore]
        public bool NameSpecified
        {
            get  { return Name != "secret"; }
        }
    }
