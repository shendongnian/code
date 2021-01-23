    class BlockProperties
    {
        public List<TestBocks> Testing { get; set; }
        public BlockProperties()
        {
            Testing = new List<TestBocks>(3);
            List<Vexel> t1 = new List<Vexel>(1);
            t1.Add(new Vexel(new Koord(1,0,1), 1));
            List<Vexel> t2 = new List<Vexel>(2);
            t2.Add(new Vexel(new Koord(2, 0, 1), 2));
            t2.Add(new Vexel(new Koord(2, 0, 2), 2));
            List<Vexel> t3 = new List<Vexel>(3);
            t3.Add(new Vexel(new Koord(3, 0, 1), 3));
            t3.Add(new Vexel(new Koord(3, 0, 2), 3));
            t3.Add(new Vexel(new Koord(3, 0, 3), 3));
            TestBocks tb1 = new TestBocks();
            tb1.Koords = t1;
            TestBocks tb2 = new TestBocks();
            tb2.Koords = t2;
            TestBocks tb3 = new TestBocks();
            tb3.Koords = t3;
            Testing.Add(tb1);
            Testing.Add(tb2);
            Testing.Add(tb3);
        [...]
        }
    [...]
    }
