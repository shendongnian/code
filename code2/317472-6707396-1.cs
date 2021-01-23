    class Program
    {
        static void Main(string[] args)
        {
            IApplicationContext ctx = new XmlApplicationContext("objects.xml");
            var worker = (IDoWorkForSomeTime)ctx.GetObject("plainWorker");
            worker.Work(4);
            var advisedWorker = (IDoWorkForSomeTime)ctx.GetObject("advisedWorker");
            advisedWorker.Work(4);
        }
    }
