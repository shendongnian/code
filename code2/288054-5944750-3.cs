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
        sCls oCls = new sCls("hi") {A = 4, B = "HI"};
	}
