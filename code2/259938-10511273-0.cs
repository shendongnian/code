	#region private variables
	private String FFolderName;
      	private List<ClassElements> ListOfElements;
	#endregion
	#region public variables
        [XmlArray("ClassListArray")]
        [XmlArrayItem("ClassElementObjects")]
        public List<ClassElements> ListOfElements = new List<ClassElements>();
        [XmlElement("Listname")]
        public string Listname { get; set; }
        public void InitilizeClassVars() 
        {
        }
	#endregion
	#region constructor
        public ClassList() 
        {
        InitilizeClassVars();
        }
 	public void AddClassElementObjects aItem)
      	{
        ListOfElements.Add(aItem);
      	}
	#endregion
