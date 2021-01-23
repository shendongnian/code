        class MyObject
        {
            public MyObject(int i1, string s1, double d1)
            {
                this.i1 = i1;
                this.s1 = s1;
                this.d1 = d1;
            }
            int i1;
            string s1;
            double d1;
        };
        static MyObject[] objects = new MyObject[] { new MyObject(1, "2", 3), new MyObject(1, "2", 3) };
