    public class MyCustomType
    {
        public int A { get; private set; }
        public int B { get; private set; }
        
        public static MyCustomType Parse(string s)
        {
            // Manipulate s and construct a new instance of MyCustomType
            var vals = s.Split(new char[] { '|' });
            
            return new MyCustomType { A = vals[0], B = vals[1] };            
        }
    }
