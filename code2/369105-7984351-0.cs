     [FlagsAttribute] 
    enum tester
    {
        alpha = 1,
        beta = 2,
        gamma = 4,
        reggy=3
    }
    class Program
    {
        static void Main(string[] args)
        {
            tester t = tester.alpha | tester.beta;
            if (t == tester.alpha)
                Console.WriteLine("alpha only");
            if ((t & tester.alpha) != 0)
                Console.WriteLine("alpha");
            if ((t & tester.beta) != 0)
                Console.WriteLine("beta");
            if ((t & tester.gamma) != 0)
                Console.WriteLine("gamma");
            if (t == (tester.beta | tester.alpha))
                Console.WriteLine("alphabeta");
            //this will produce alpha, beta, alphabeta
            
