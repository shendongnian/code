        #region Singleton Clazz
        public sealed class Clazz
        {
            private readonly static Clazz _instance = new Clazz();
        
            public static Clazz Instance  { get { return _instance; } }
        
            private Clazz()
            {
                // implementation here
            }
        }
