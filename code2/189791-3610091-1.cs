    public class MyCustomType
    {
        public int A { get; private set; }
        public int B { get; private set; }
        
        public static MyCustomType Parse(string s)
        {
            // Manipulate s and construct a new instance of MyCustomType
            var vals = s.Split(new char[] { '|' })
                .Select(i => int.Parse(i))
                .ToArray();
            if(vals.Length != 2)
                throw new FormatException("Invalid format.");
            
            return new MyCustomType { A = vals[0], B = vals[1] };            
        }
    }
