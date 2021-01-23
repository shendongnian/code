    [ProtoContract]
    [ProtoInclude(1, typeof(Integer))]
    [ProtoInclude(2, typeof(String))]
    public abstract class Variant
    {
        [ProtoContract]
        public sealed class Integer
        {
            [ProtoMember(1)]
            public int Value;
        }
        [ProtoContract]
        public sealed class String
        {
            [ProtoMember(1)]
            public string Value;
        }
    }
