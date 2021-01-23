    public class IdTypeAttribute: Attribute
    {
        public string IdType { get; private set; }
        public IdTypeAttribute(string idType)
        {
            IdType = idType;
        }
    }
    [IdType("B")]
    public class SuperContainerB: Container
    {
        // whatever you like...
    }
