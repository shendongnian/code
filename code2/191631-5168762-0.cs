    public class GenericFactory
    {
        public static T Create<T>(object[] args)
        {
            var types = new Type[args.Length];
            for (var i = 0; i < args.Length; i++)
                types[i] = args[i].GetType();
            return (T)typeof(T).GetConstructor(types).Invoke(args);
        }
    }
