    class Program
    {
        static void Main(string[] args)
        {
            IApplicationContext ctx = new XmlApplicationContext("objects.xml");
            var worker = (IDoWorkForSomeTime)ctx.GetObject("plainWorker");
            var advisedWorker = (IDoWorkForSomeTime)ctx.GetObject("advisedWorker");
            
            worker.Work(4);
            advisedWorker.Work(4);
        }
    }
