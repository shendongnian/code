        public static void Main(string[] args)
        {
            var threadPool = new SmartThreadPool();
            IWorkItemResult<int> workItem=null;
            SmartThreadPool.WaitAll(new IWaitableResult[ ]{workItem = threadPool.QueueWorkItem(new Amib.Threading.Func<int, int, int>(Add), 1, 2)});
            Console.WriteLine(workItem.Result);
            Console.ReadLine();
        }
        public static int Add(int a, int b)
        {
            return a+b;
        }
