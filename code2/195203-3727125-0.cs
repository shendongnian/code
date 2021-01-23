    [Serializable]
    public class MyClass
    {
         [Nonserialized]
         private DataTable _myProperty;
         [XmlIgnore]
         public DataTable MyProperty { get; set; }
    }
