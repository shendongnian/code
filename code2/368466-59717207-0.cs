    //.Net Core 3.1
        class Convertors
        {
            static void Main(string[] args)
            {
                Console.WriteLine(Convertors.ConvertAny("m","cm", 10));
                Console.ReadKey();
            }
            public static double MToCM(double value)
            {
                return value * 100;
            }
            public static double ConvertAny(string srcUOM, string tgtUOM, double value)
            {
                switch (srcUOM.ToLower(), tgtUOM.ToLower())
                {
                    case ("m", "cm"): return Convertors.MToCM(value);
                    default: throw new NotImplementedException();
                }
            }
        }
