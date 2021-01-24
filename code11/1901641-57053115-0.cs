    public class Foo
    {
        public string A = string.Empty;
        public string B = string.Empty;
        public string C = string.Empty;
        public string D = string.Empty;
    
        public override string ToString()
        {
            return A + "," + B + "," + C + "," + D;
        }
    }
    Foo foo = new Foo
    {
        A = "Tom",
        B = "Mark",
        C = "Paul",
        D = "John"
    };
    string s = foo.ToString();
