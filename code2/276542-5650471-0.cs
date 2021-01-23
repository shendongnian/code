    public class Usage
    {
        public static Usage<T2> For<T2>(T2 t2)
        {
            return new Usage<T2>(t2);
        }
    }
    public class Usage<T2>
    {
        private readonly T2 t2; // Assuming we need it
        public Usage(T2 t2)
        {
            this.t2 = t2;
        }
        // I don't know what return type you really want here
        public static Foo Create<T1>() where T1 : GenericWrapper<T2>
        {
            // Whatever
        }
    }
