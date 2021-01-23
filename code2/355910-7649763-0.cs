    class TestFixture
    {
        //... properties
        public TestFixture()
        {
            this.init();
        }
        public TestFixture(string a, int b, int c, string d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.init();
        }
        private void init()
        {
            e= dosomething(a, b);
            f= false;
            g = DateTime.Now.ToString("yyMMddhhmmss");
            h= TestName.Equals("1") && b.Equals("2") ? 1000 : 1;
            i= 10000000;
            j= a.Equals("FOT");
            k = false;
        }
    }
