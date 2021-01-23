    public class Foo 
    {
        #region Singleton
        Foo()
        {
        }
        public static Foo Instance
        {
            get
            {
                return Nested.instance;
            }
        }
        class Nested
        {
            static Nested() { }
            internal static readonly Foo instance = new Foo();
        }
        #endregion
 
