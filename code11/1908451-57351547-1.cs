    [XmlIncludeAttribute(typeof(A))]
    [XmlIncludeAttribute(typeof(B))]
    class AorB
    {
    }
    class A : AorB
    {
    }
    class B : AorB
    {
    }
    class ToSerialize
    {
        public AorB MyObject { get; set; }
    }
You could create a common base class instead of using object to be more specific.
