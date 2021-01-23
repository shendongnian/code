    public static class Factories
    {
        public static Func<T> GetInstanceFactory<T>(params object[] args)
        {
            var type = typeof(T);
            var ctor = null as System.Reflection.ConstructorInfo;
            if (args != null && args.Length > 0)
                ctor = type.GetConstructor(args.Select(arg => arg.GetType()).ToArray());
            if (ctor == null)
                ctor = type.GetConstructor(new Type[] { });
            if (ctor == null)
                throw new ArgumentException("Cannot find suitable constructor for object");
            return () => (T)ctor.Invoke(args.ToArray());
        }
    }
    // usage
    var oooooFactory = Factories.GetInstanceFactory<string>('o', 5); // create strings of repeated characters
    oooooFactory(); // "ooooo"
