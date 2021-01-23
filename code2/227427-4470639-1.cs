    abstract class BaseClass<K,T> where T : BaseClass<K,T>, new()
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                _instance = _instance ?? new T();
                return _instance;
            }
        }
    }
    
    class ActualClass : BaseClass<int, ActualClass>
    {
        public ActualClass() {}
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ActualClass.Instance.GetType().ToString());
            Console.ReadLine();
        }
    }
