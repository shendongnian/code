    class Rates
    {
        public double Limit{get;}
        public double LowRate{get;}
        public double HighRate{get;}
        static readonly Rates default = new Rates(30000,0.15,0.28);
        static readonly Rates govna = new Rates(300000,0.1,0.2);
        static readonly Rates priest = new Rates(300,0.05,0.07);
        public static Rates createRates()
        {
            double Limit; double LowRate; double HighRate;
            Console.Write("Enter dollar limit: ");              
            Limit = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the low rate: ");
            LowRate = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the high rate: ");
            HighRate = Convert.ToDouble(Console.ReadLine());
            return new Rates( Limit, LowRate, HighRate );
        }
        private Rates(double limit; double lowRate; double highRate;)
        {
            Limit = limit;
            LowRate = lowRate;
            HighRate = highRate;
        }
        public double CalculateTax( double Income)
        {
            if(Income < Limit)
            {return (Income * LowRate)}
            else
            {return (Income * HighRate)}
        }
    }
