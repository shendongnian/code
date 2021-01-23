        public class BSE
        {
            public BSE()
            {
                BaseA = "Bob";
            }
            public string BaseA;
        }
        public class sCls :BSE
        {
            
            public int A;
            public string B;
        }
	static void Main(string[] args)
	{
            sCls oCls = new sCls() {A = 4, B = "HI" };
            Console.WriteLine("{0}", oCls.BaseA);//Prints Bob
	}
