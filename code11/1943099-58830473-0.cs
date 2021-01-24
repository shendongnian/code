    try this ,Use must Call start For Initializing a:
    
        public class Tcp
        {
            private int _a;
            public void start()
            {
                int[] i = { 10, 20, 30, 40, 50 };
                a = i[0];
            }
            public int a
            {
                get
                {
                    return _a;
                }
                set
                {
                    _a = value;
                }
            }
        }
    
            Tcp t = new Tcp();
            t.start();
            Console.WriteLine(t.a);
