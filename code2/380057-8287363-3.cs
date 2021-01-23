    [XmlType("Object", Namespace = "", TypeName = "Object")]
    public class dtoObject : CommonBase   
    {       
        [XmlArray("SomeItems"), XmlArrayItem("SomeItem")]       
        public List<dtoSomeItem> SomeItems       
        {
            get { return _SomeItems; }           
            set { _SomeItems = value; }       
        }    
    }
