    public class HasVolatileImmutableType
    {
        public volatile string MyVolatileMember; 
    }
    
    // usage
    HasVolatileImmutableType example = new HasVolatileImmutableType();
    example.MyVolatileMember = "immutable";
    // string is reference type, but is *immutable*, 
    // so we need to reasign the modification result it in order 
    // to work with the new value later
    example.MyVolatileMember = example.MyVolatileMember.SubString(2);
