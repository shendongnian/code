    struct S
    {
        int y;
        public void M(int x) 
        { 
            Console.WriteLine(x + y); 
        }
    }
    ...
    S s = new S();
    s.M(10);
