    public static class REF
    {
        public static Type[][] CONST { get; }
        static REF()
        {
            Dictionary<Enum, List<Enum>> REF = new Dictionary<Enum, List<Enum>>();
            REF.Add(TYPE.hum, new List<Enum>());
            foreach (var item in Enum.GetValues(typeof(HUM)))
            {
                REF[TYPE.hum].Add((HUM)item);
            }
            // Demo code, print all values in TYPE.hum
            foreach (var item in REF[TYPE.hum])
            {
                Console.WriteLine(item);
            }
        }
    }
