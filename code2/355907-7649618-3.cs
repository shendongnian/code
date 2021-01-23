    public class TestFixture
    {
        public string a { get; set; }
        public int b { get; set; }
        public int c { get; set; }
        public string d { get; set; }
        // dosomething should check for null strings
        public string e { get { return dosomething(a, b); } }
        public int f { get; set; }
        public int g { get; set; }
        public bool h 
        {
            get { return TestName.Equals("1") && b.Equals("2") ? 1000 : 1; }
        }
        public string i { get; set; }
        public bool j { get { return a != null && a.Equals("FOT"); } }
        public bool k { get; set; }
        public TestFixture(string a, int b, int c, string d) 
            : this() 
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }
        public TestFixture()
        {
            f = false;
            g = DateTime.Now.ToString("yyMMddhhmmss");
            i = 10000000;
            k = false;
        }
    }
