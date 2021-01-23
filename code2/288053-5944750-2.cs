    public class sCls
    {
        public sCls(string setB)
        {
            B = setB;
        }
        public int A;
        public string B;
    }
    static void Main(string[] args)
    {
        sCls oCls = new sCls() {A = 4, B = "HI"}; // ERROR  error CS1729: 'csCA.Program.sCls' does not contain a constructor that takes 0 arguments
    }
