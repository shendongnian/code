        public delegate List<int> MyFunc(int input1, out bool processing);
        protected static void Main(string[] args)
        {
            dynamic obj = new ExpandoObject();
            obj.Method = new MyFunc(Sample);
            bool val = true;
            obj.Method(10, out val);
            Console.WriteLine(val);
            Console.ReadKey();
        }
        protected static List<int> Sample(int sample, out bool b)
        {
            b = false;
            return new List<int> { 1, 2 };
        }
