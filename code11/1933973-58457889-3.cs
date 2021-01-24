       class Program
    {
        // Create List with type of the ITimeMulti interface
        public static List<ITimeMulti> Minutes = new List<ITimeMulti>();
        static void Main(string[] args)
        {
            // Generate a sample
            for (int i = 1; i < 10000000; i++)
                Minutes.Add(new Minute() { Source = i});
            // Calculate 
            GenerateMultipliers(Minutes, 1, 2); 
        }
        public static void GenerateMultipliers(List<ITimeMulti> source, int multNumber, int multiplier)
        {
            for (int i = 0; i < source.Count; i++)
            {
                source[i].Generate(multNumber, multiplier);
            }
        }
    }
