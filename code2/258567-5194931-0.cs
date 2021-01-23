    public class SomeCollection
    {
        [XmlIgnore]
        public SomeClass this[int i]
        {
            get { ... }
            set { ... }
        }
        [XmlArray(ElementName="someClasses")]
        [XmlArrayItem(ElementName="someClass", Type=typeof(SomeClass))]
        public List<SomeClass> someClasses
        {
            get
            {
                // tie this into the same collection access by the indexer...
            }
            set
            {
                // tie this into the same collection access by the indexer...
            }
        }
}
