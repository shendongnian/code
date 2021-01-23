    //[XmlInclude(typeof(B))]
    [Serializable]
    public class A : ReactListObject
    {
        public int AValue = 1;
    }
    
    [XmlInclude(typeof(A))]
    public class B : A
    {
        public int BValue = 2;
    }
