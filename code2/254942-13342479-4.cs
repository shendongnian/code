    public class HasVolatileReferenceType
    {
        public volatile List<int> MyVolatileMember;
    }
    // usage
    HasVolatileReferenceTypeexample = new HasVolatileReferenceType();
    // instead of modifying `example.MyVolatileMember`
    // we are replacing it with a new list. This is OK with volatile.
    example.MyVolatileMember = example.MyVolatileMember
         .Where(x => x > 42).ToList();
    // This, however is error prone:
    example.MyVolatileMember.RemoveAll(x => x <= 42);
