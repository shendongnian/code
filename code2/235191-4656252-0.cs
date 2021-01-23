    class A
    {
        public string Blah { get; set; }
    }
    void Do (ref A a)
    {
        a = new A { Blah = "Bar" };
    }
