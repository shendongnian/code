        static void Main(string[] args)
        {
            Dictionary<string, List<string>> SpecTimes = new Dictionary<string, List<string>>();
            List<string> times = new List<string>();
            int count;
            times.Add("000.00.00");
            times.Add("000.00.00");
            times.Add("000.00.00");
            times.Add("000.00.01");
            string spec = "A101";
            SpecTimes.Add(spec,times);
            // gives 4
            count = SpecTimes[spec].Count;
            // gives 3
            count = (from i in SpecTimes[spec] where i == "000.00.00" select i).Count();
            // gives 1
            count = (from i in SpecTimes[spec] where i == "000.00.01" select i).Count();
        }
