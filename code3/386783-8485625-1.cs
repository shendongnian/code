    [Trace]
    public class MyClass
    {
        // ...
    // or
    #if DEBUG
    [assembly: Trace( AttributeTargetTypes = "MyNamespace.*",
        AttributeTargetTypeAttributes = MulticastAttributes.Public,
        AttributeTargetMemberAttributes = MulticastAttributes.Public )]
    #endif
