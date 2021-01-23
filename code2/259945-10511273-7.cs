    using System.Xml.Serialization;
    
    [XmlRoot("ClassList")]
    [XmlInclude(typeof(ClassElements))] //Adds class containing elentsof list
    public class ClassList
    {
        private String FFolderName;
      	private List<ClassElements> ListOfElements;
        
        [XmlArray("ClassListArray")]
        [XmlArrayItem("ClassElementObjects")]
        public List<ClassElements> ListOfElements = new List<ClassElements>();
        [XmlElement("Listname")]
        public string Listname { get; set; }
        public void InitilizeClassVars() 
        {
        }
        public ClassList() 
        {
            InitilizeClassVars();
        }
        public void AddClassElementObjects aItem)
        {
            ListOfElements.Add(aItem);
        }
    }
    [XmlType("ClassElements")]
    public class ClassElements
    {
        private String str1;
        private int iInt;
        private Double dblDouble;
        [XmlAttribute("str", DataType = "string")]
        public String str
        {
            get { return str; }
        }
        
        [XmlElement("iInt")]
        public int iInt
        {
            get { return iInt;}
            set { iInt = value; }
        }
    
        [XmlElement("dblDouble")]
        public Double dblDouble
        {
            get { return dblDouble; }
            set { dblDouble = value; }
        }
        public void InitilizeClassVars()
        {
        }
        public ClassElements()
        {
            InitilizeClassVars();
        }
    }
