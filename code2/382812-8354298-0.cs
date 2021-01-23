    class CallRecord
    {
        public long NumberDialled { get; set; }
        public DateTime Stamp { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var calls = new List<CallRecord>()
            {
                new CallRecord { NumberDialled=123, Stamp=new DateTime(2011,01,01,10,10,0) },
                new CallRecord { NumberDialled=123, Stamp=new DateTime(2011,01,01,10,10,9) },
                new CallRecord { NumberDialled=123, Stamp=new DateTime(2011,01,01,10,10,18) },
            };
            var dupCalls = calls.Where(x => calls.Any(y => y.NumberDialled == x.NumberDialled && (x.Stamp - y.Stamp).Seconds > 0 && (x.Stamp - y.Stamp).Seconds <= 10)).Select(x => x.NumberDialled).Distinct();
            foreach (var dupCall in dupCalls)
            {
                Console.WriteLine(dupCall);
            }
            Console.ReadKey();
        }
    }
