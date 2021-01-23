    public class MyClass
    {
        public string A { get; set; }
        public string B { get; set; }
        public MyClass(string a, string b)
        {
            Debug.Assert(a != null);
            Debug.Assert(b != null);
            
            this.A = a;
            this.B = b;
        }
    }
