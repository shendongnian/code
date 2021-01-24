    public static class Singleton {
        public static T For<T>(Func<T> makeSingleton) => Singleton<T>.For(makeSingleton);
    }
    public static class Singleton<T> {
        static Dictionary<Func<T>, T> Cache = new Dictionary<Func<T>, T>();
    
        public static T For(Func<T> makeSingleton) {
            T singleton;
            if (!Cache.TryGetValue(makeSingleton, out singleton)) {
                singleton = makeSingleton();
                Cache[makeSingleton] = singleton;
            }
    
            return singleton;
        }
    }
