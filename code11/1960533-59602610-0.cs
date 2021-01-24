    class TestClass
    {
        private Dictionary<string, int> _dict;
        public Dictionary<string, int> dict
        {
            get
            {
                if (_dict == null)
                {
                    Sing();
                }
                return _dict;
            }
            set { _dict = value; }
        }
    
        private void Sing()
        {
            _dict = new Dictionary<string, int>()
            {
                ["A"] = 1,
                ["B"] = 2,
                ["C"] = 3
            };
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            xtra.TestClass Joe = new xtra.TestClass();
            foreach (string name in Joe.dict.Keys)
                sys.Console.WriteLine($"{name} {Joe.dict[name]}");
            Console.ReadLine();
        }
    }
