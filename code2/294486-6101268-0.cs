    class MyObject
    {
        public int i1 { get; set; }
        public string s1 { get; set; }
        public double d1 { get; set; }
    }   // note: no semicolon needed here
    static MyObject[] myO = { new MyObject { i1 = 1, s1 = "1", d1 = 1.0 },
                              new MyObject { i1 = 2, s1 = "2", d1 = 2.0 },
                            };
