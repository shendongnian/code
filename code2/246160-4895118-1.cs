    [Serializable]
    public class Foo : Dictionary<string, string>
    {
        public Foo()
            : base()
        {
        }
        public Foo(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }   
    }
