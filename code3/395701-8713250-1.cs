        enum PossibleOutcome { A, B, C, D, Undefined }
        // sample data: possible outcome vs its probability
        static readonly Dictionary<PossibleOutcome, double> probabilities = new Dictionary<PossibleOutcome, double>()
        {
            {PossibleOutcome.A, 0.31},
            {PossibleOutcome.B, 0.14},
            {PossibleOutcome.C, 0.30},
            {PossibleOutcome.D, 0.25}
        };
        static Random random = new Random();       
        static PossibleOutcome GetValue()
        {            
            var result = random.NextDouble();
            var sum = 0.0;
            foreach (var probability in probabilities)
            {
                sum += probability.Value;
                if (result <= sum)
                {
                    return probability.Key;
                }                
            }
            return PossibleOutcome.Undefined; // it shouldn't happen
        }
        static void Main(string[] args)
        {
            if (probabilities.Sum(pair => pair.Value) != 1.0)
            {
                throw new ApplicationException("Probabilities must add up to 100%!");
            }
            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine(GetValue().ToString());
            }
            Console.ReadLine();            
        }
