    // deeply broken, do not use!
    class Singleton {
        private static object slock = new object();
        private static Singleton instance;
        private static bool initialized;
        private Singleton() {}
        public Instance {
            get {
                if (!initialized) {
                    lock (slock) {
                        if (!initialized) {
                            instance = new Singleton();
                            initialized = true;
                        }
                    }
                }
                return instance;
            }
        }
    }
