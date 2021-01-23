    struct S
    {
        int y;
        public static void M(ref S _this, int x) 
        { 
            Console.WriteLine(x + _this.y); 
        }
    }
    ...
    S s = new S();
    S.M(ref s, 10);
