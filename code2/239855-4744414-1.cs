    [ProtoContract]
    public class Foo {
        [ProtoMember(1, Options = MemberSerializationOptions.Packed)]
        public int[] Bar {get;set;}
    }
