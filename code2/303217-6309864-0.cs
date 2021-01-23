    internal class ClassA
    {
        public WriteLog Log { get; set; }
        public ClassA(WriteLog writeLog)
        {
            Log = writeLog;
        }
        public void Search()
        {
            Log.Print("Test");
        }
    }
    class classB
    {
        private ClassA m_classA;
        protected void WriteLogCallBack(string msg)
        {
            // prints msg
            /* ... */
            Console.WriteLine(msg);
        }
        public classB()
        {
            m_classA = new ClassA(new WriteLog(WriteLogCallBack));
        }
        
        public void test1()
        {
            Thread thread = new Thread(new ThreadStart(Run));
            thread.Start();
        }
        public void test2()
        {
            m_classA.Search();
        }
        public void Run()
        {
            while (true)
            {
                /* ... */
                m_classA.Search();
                /* ... */
                Thread.Sleep(1000);
            }
        }
    }
    internal class WriteLog
    {
        private Action<string> Callback { get; set; }
        public WriteLog(Action<string> writeLogCallBack)
        {
            Callback = writeLogCallBack;
        }
        public void Print(string msg)
        {
            Callback(msg);
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            classB b = new classB();
            b.test1();
            }
    }
