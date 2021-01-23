    public class MyWrapper<T1, T2, T3>
    {
        private IDictionary<T1, IDictionary<T2, T3>> dictionary;
        public MyWrapper()
        {
            dictionary = new Dictionary<T1, IDictionary<T2, T3>>();
        }
        public static void Main(string[] args)
        {
            var myWrapper = new MyWrapper<int, string, bool>();
        }
    }
