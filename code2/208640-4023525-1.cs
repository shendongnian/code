    public class ExternalClass
    {
        // Here you are definining a type.
        public class InternalClass
        {
            public int SomeNumber {get;set}
        }
        // And here are some properties providing access to
        // actual objects...
        public string Name { get; set; }
        // ...including an instance of the type you defined
        // above.
        public InternalClass InternalInstance { get; private set; }
        public ExternalClass()
        {
            InternalInstance = new InternalClass();
        }
    }
