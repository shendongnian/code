    public class Test
    {
        static T CreateT<T>(bool _new) where T: new()
        {
            if (_new) return new T(); else return default(T);
        }
        public static void Main()
        {
            var o = CreateT<object>(true);
        }
    }
