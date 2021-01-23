    class Singleton 
    {
      private static object slock = new object();
      private static Singleton instance;
      private static int initialized;
      private Singleton() {}
      
      public Instance {
        get {
            var local = instance;
            if (initialized == 0) {
                lock (slock) {
                    if (initialized == 0) {
                        instance = new Singleton();
                        initialized = 1;
                    }
                }
            }
            return local;
        }
      }
    }
