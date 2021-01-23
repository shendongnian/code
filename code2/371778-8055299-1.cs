        public class MyObject : IMyBindingObject
    {
        public MyObject(string a, string b, string c)
        {
            A = a;
            B = b;
            C = c;
        }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
    }
