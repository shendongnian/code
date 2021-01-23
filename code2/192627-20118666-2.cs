    void Main()
    {
    	var source=
    		new TestClass() 
    		{ 
    			GroupTestTyped=
    				new Dictionary<string, int> { {"A", 23}, {"B", 40} }
    		};
        using (var writer = XmlWriter.Create("c:\\test1.xml"))
            (new XmlSerializer(typeof(TestClass))).Serialize(writer, source);
    }
    [Serializable]
    public class DemoElementClass
    {
        public string Key { get; set; }
        public int Value { get; set; }  
    }
    [Serializable]
    public class TestClass
    {
       public TestClass() { }
    
       [XmlArray]
       [XmlArrayItem(ElementName = "ElementTest")]
       public List<DemoElementClass> GroupTest { get; set; }
    
       [XmlIgnore]
       public Dictionary<string, int> GroupTestTyped 
       {
           get { return GroupTest.ToDictionary(x=> x.Key, x => x.Value); }
           set { GroupTest = value.Select(x => new DemoElementClass {Key = x.Key, Value = x.Value}).ToList(); }
       }
    }
