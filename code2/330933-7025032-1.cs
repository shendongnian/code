    class A1
    {
        public int Id { get; set; }
    }
    class A2
    {
        public int Id { get; set; }
    }
       A1 a = new A1();
       A2 b = (A2) a;    // error 
