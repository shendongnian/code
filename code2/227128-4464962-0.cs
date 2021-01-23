    class MyWorker 
    {
        public string MyType {get; set;}
        public static PriorityBlockingQueue<string, MyInfo> data; 
    
        public static void DoWork()
        {
            while(true)
            {
                MyInfo value;
                if (data.TryTake(MyType, timeout, out value))
                {
                    // OK, do work
                }
            }
        }
    }
