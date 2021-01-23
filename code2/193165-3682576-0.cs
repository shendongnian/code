        class RNB
        {
            public RNB(double roomRate, double roomDays)
            {
                RoomRate = roomRate;
                RoomDays = roomDays;
            }
            public double RoomRate { get; set; }
            public double RoomDays { get; set; }
            public const double BasicLimit = 100;
        }
        class HMS
        {
            public double Amount { get; set; }
            public const double BasicLimit = 200;
        }
        public static double ComputeBasicAmount(double basicLimit, Func<double> multiplier)
        {
            return basicLimit * multiplier();
        }
        static void Main(string[] args)
        {
            RNB rnb = new RNB(100, 2);
            double result = ComputeBasicAmount(RNB.BasicLimit, () => rnb.RoomDays * rnb.RoomRate);
            Console.WriteLine("RNB Basic Amt: " + result.ToString());
            HMS hms = new HMS() { Amount = 1000 };
            result = ComputeBasicAmount(HMS.BasicLimit, () => hms.Amount);
            Console.WriteLine("HMS Basic Amt: " + result.ToString());
            Console.Read();
        }
