    class Test
    {
        static void Main()
        {
            var obj = new Test();
            Stopwatch watch;
            const int LOOP = 500000000;
            watch = Stopwatch.StartNew();
            for (int i = 0; i < LOOP; i++)
            {
                obj.AutoProp = 17;
            }
            watch.Stop();
            Console.WriteLine("AutoProp: {0}ms", watch.ElapsedMilliseconds);
            watch = Stopwatch.StartNew();
            for (int i = 0; i < LOOP; i++)
            {
                obj.Field = 17;
            }
            watch.Stop();
            Console.WriteLine("Field: {0}ms", watch.ElapsedMilliseconds);
            watch = Stopwatch.StartNew();
            for (int i = 0; i < LOOP; i++)
            {
                obj.BasicProp = 17;
            }
            watch.Stop();
            Console.WriteLine("BasicProp: {0}ms", watch.ElapsedMilliseconds);
            watch = Stopwatch.StartNew();
            for (int i = 0; i < LOOP; i++)
            {
                obj.CheckedProp = 17;
            }
            watch.Stop();
            Console.WriteLine("CheckedProp: {0}ms", watch.ElapsedMilliseconds);
            Console.ReadLine();
        }
        public int AutoProp { get; set; }
        public int Field;
        private int basicProp;
        public int BasicProp
        {
            get { return basicProp; }
            set { basicProp = value; }
        }
        private int checkedProp;
        public int CheckedProp
        {
            get { return checkedProp; }
            set { if (value != checkedProp) checkedProp = value; }
        }
    }
