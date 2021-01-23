    public class HasVolatileImmutableType
    {
        public volatile string MyVolatileMember; 
    }
    
    // usage
    HasVolatileImmutableType example = new HasVolatileImmutableType();
    // string is reference type, but is immutable, 
    // so we need to reasign it in order to change it
    example.MyVolatileMember = example.MyVolatileMember.SubString(1);
