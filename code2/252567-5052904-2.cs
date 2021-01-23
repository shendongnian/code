        public class SomeClass
        {
            public static List<int> data = new List<int>();
            public static readonly object obj = new object();
            public void SomeMethod(int[] ids)
            {
                foreach (int id in ids)
                {
                    Work w = new Work();
                    w.Data = id;
                    w.callback = ResultCallback; 
                    var myThread = new Thread(new ThreadStart(w.DoWork));
                    myThread.Start();
                }
            }
            public static void ResultCallback(int d)
            {        
                lock (obj)
                {        
                    data.Add(d);
                }
            }
        }
        public delegate void ExampleCallback(int data); 
        class Work
        {
            public int Data { get; set; }
            public ExampleCallback callback;
            
            public void DoWork()
            {                
                Console.WriteLine("Instance thread procedure. Data={0}", Data);
                if (callback != null)
                    callback(Data);
            }
        }
