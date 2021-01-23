    class C
    {
        int y;
        public void M(int x) 
        { 
            Console.WriteLine(x + y); 
        }
    }
    ...
    C c = new C();
    c.M(10);
