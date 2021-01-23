    public class Foo
    {
        private static Foo _Instance = new Foo();
        public static Type Bar()
        {
            return _Instance.GetType();
        }
    }
