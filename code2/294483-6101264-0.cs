    class MyObject 
    {
        int i1;
        string s1;
        double d1;
    
        public MyObject(int i, string s, double d)
        {
            i1 = i;
            s1 = s;
            d1 = d;
        }
    };
    
    static MyObject[] myO = new MyObject[] { 
        new MyObject(1, "1", 1.0), 
        new MyObject(2, "2", 2.0)
    };
