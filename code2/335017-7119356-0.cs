    class Singleton{
        public static Singleton Instance() {
            if (_instance == null) {
                lock(typeof(Singleton)) {
                    if (_instance == null) {
                        _instance = new Singleton();
                    }
                }
            }
            return _instance;
        }
        protected Singleton() {}
        private static Singleton _instance = null;
    }
