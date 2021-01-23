    public class Class1
    {
        private string _Property1;
        public string Property2 { get; set; }
        public DateTime AddedProperty { get; set; }
        public Class1()
        {
        }
        public Class1(string prop1, string prop2)
        {
            _Property1 = prop1;
            Property2 = prop2;
        }
        public string Property1 
        { 
            get { return _Property1; }
            set { }
        }
    }
