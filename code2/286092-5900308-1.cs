    class C
    {
        int y;
        public static void M(C _this, int x) 
        { 
            Console.WriteLine(x + _this.y); 
        }
    }
    ...
    C c = new C();
    C.M(c, 10);
