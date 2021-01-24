    using System.Collections.Generic;
    
    class Startup
    {
        static void Main()
        {
            int entry = 1233;
            List<Info>[] test = new List<Info>[entry];
    
            for (int i = 0; i < 500 ; i+=3)
            {
                Info info1 = new Info()
                {
                    capacity = i * 2,
                    name = i.ToString()
                };
                test[i] = new List<Info> {info1};
            }
            for (int i = 0; i < 1000; i+=5)
            {
                Info info2 = new Info();
                info2.capacity = i * 2;
                info2.name = i.ToString() + i.ToString();
                test[i] = new List<Info> {info2};
            }
        }
    
        struct Info
        {
            public int capacity;
            public string name;
        }
    }
