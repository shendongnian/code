    class Program
    {
        public sealed class Pairing
        {
            public int Index { get; private set; }
            public int Length { get; private set; }
            public int Offset { get; private set; }
            public Pairing(int index, int length, int offset)
            {
                Index = index;
                Length = length;
                Offset = offset;
            }
        }
        public static IEnumerable<Pairing> FindPairings(string genome, int minLen, int maxLen, int intervalMinLen, int intervalMaxLen)
        {
            int n = genome.Length;
            var padding = new string((char)0, maxLen);
            var padded = string.Concat(padding, genome, padding);
            int start = (intervalMinLen + minLen)/2 + maxLen;
            int end = n - (intervalMinLen + minLen)/2 + maxLen;
            //Consider 'fold locations' along the genome
            for (int i=start; i<end; i++)
            {
                //Consider 'odd' folding (centered on index) about index i
                int k = (intervalMinLen+2)/2;
                int maxK = (intervalMaxLen + 2)/2;
                while (k<=maxK)
                {
                    int matchLength = 0;
                    while (IsPaired(padded[i - k], padded[i + k]) && (k <= (maxK+maxLen)))
                    {
                        matchLength++;
                        if (matchLength >= minLen && matchLength <= maxLen)
                        {
                            yield return new Pairing(i-k - maxLen, matchLength, 2*k - (matchLength-1));
                        }
                        k++;
                    }
                    k++;
                }
                //Consider 'even' folding (centered before index) about index i
                k = (intervalMinLen+1)/2;
                while (k <= maxK)
                {
                    int matchLength = 0;
                    while (IsPaired(padded[i - (k+1)], padded[i + k]) && (k<=maxK+maxLen))
                    {
                        matchLength++;
                        if (matchLength >= minLen && matchLength <= maxLen)
                        {
                            yield return new Pairing(i - (k+1) - maxLen, matchLength, 2*k + 1 - (matchLength-1));
                        }
                        k++;
                    }
                    k++;
                }
            }
        }
        private const int SumAT = 'A' + 'T';
        private const int SumGC = 'G' + 'C';
        private static bool IsPaired(char a, char b)
        {
            return (a + b) == SumAT || (a + b) == SumGC;
        }
        static void Main(string[] args)
        {
            string genome = "ATCAGGACCATACGCCTGAT";
            foreach (var pairing in FindPairings(genome, 4, 5, 9, 10))
            {
                Console.WriteLine("'{0}' pair with '{1}'",
                                  genome.Substring(pairing.Index, pairing.Length),
                                  genome.Substring(pairing.Index + pairing.Offset, pairing.Length));
            }
            Console.ReadKey();
        }
    }
