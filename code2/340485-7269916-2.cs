        [WebMethod]
        public void AddSomeClass1([param: XmlElement(
            Namespace = "http://tempuri.org/Namespace1",
            ElementName = "SomeClass")] MyNamespace1.SomeClass class1)
        {
        }
        [WebMethod]
        public void AddSomeClass2([param: XmlElement(
            Namespace = "http://tempuri.org/Namespace2",
            ElementName = "SomeClass")] MyNamespace2.SomeClass class2)
        {
        }
