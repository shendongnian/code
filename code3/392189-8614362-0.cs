    interface ITest
    {
        void Output(string message, int times = 1, int lineBreaks = 1);
    }
    class Test : ITest
    {
        public void Output(string message, int numTimes, int numLineBreaks)
        {
            for (int i = 0; i < numTimes; ++i)
            {
                Console.Write(message);
                for (int lb = 0; lb < numLineBreaks; ++lb )
                    Console.WriteLine();
             }
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ITest testInterface = new Test();
            testInterface.Output("ABC", lineBreaks : 3);
        }
    }
