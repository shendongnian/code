    [XmlInclude(typeof(B))]
    class A : IXmlSerializable
    {     ...
    }
    
    class B : A
    {
       public string X;
    }
