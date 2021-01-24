    class Program
    {
        public string[] strA;
        public string[] strB;
        public void SetAB(string[] strC)
        {
            this.strA = strC;
            this.strB = strC;
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.SetAB(new string[2] { "set from SetAB()", "set from SetAB()" });
            Console.WriteLine("strA[0] = " + p.strA[0]);
            Console.WriteLine("strB[0] = " + p.strB[0]);
            Console.WriteLine();
            p.strA[0] = "Test";
            Console.WriteLine("strA[0] = " + p.strA[0]);
            Console.WriteLine("strB[0] = " + p.strB[0]);
            // Why result is such?
            //strA[0] = set from SetAB()
            //strB[0] = set from SetAB()
            //strA[0] = Test
            //strB[0] = Test
        }
    }
