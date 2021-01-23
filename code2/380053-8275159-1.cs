    [XmlType("Objects")]
    public class dtoObject : CommonBase
    {
        [XmlElement("Object")]
        public List<dtoSomeItemWrapper> SomeItemsWrappers
        {
            get { return _SomeItemsWrappers; }
            set { _SomeItemsWrappers = value; }
        }
     }
    
    class dtoSomeItemWrapper
    {
        [XmlArray("SomeItems"), XmlArrayItem("SomeItem")]
        public List<dtoSomeItem> SomeItems
        {
            get { return _SomeItems; }
            set { _SomeItems = value; }
        }
    }   
