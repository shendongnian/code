    static Tuple<IList<Tuple<string, int>>, int> GenerateBaseNumbers()
    {
        const string letters = "IVXLCDM";
        var tuples = new List<Tuple<string, int>>();
        Tuple<string, int> subtractor = null;
        int num = 1;
        int maxNumber = 0;
        for (int i = 0; i < letters.Length; i++)
        {
            string currentLetter = letters[i].ToString();
            bool isEven = i % 2 == 0;
            if (subtractor != null)
            {
                tuples.Add(Tuple.Create(subtractor.Item1 + currentLetter, num - subtractor.Item2));
            }
            if (isEven)
            {
                string composedNumber = string.Empty;
                for (int j = 0; j < 3; j++)
                {
                    composedNumber += currentLetter;
                    tuples.Add(Tuple.Create(composedNumber, num * (j + 1)));
                }
                subtractor = tuples[tuples.Count - 3];
            }
            else
            {
                tuples.Add(Tuple.Create(currentLetter, num));
            }
            maxNumber += isEven ? num * 3 : num;
            num *= isEven ? 5 : 2;
        }
        return Tuple.Create((IList<Tuple<string, int>>)new ReadOnlyCollection<Tuple<string, int>>(tuples), maxNumber);
    }
    static readonly Tuple<IList<Tuple<string, int>>, int> RomanBaseNumbers = GenerateBaseNumbers();
    static string FromNumberToRoman(int num)
    {
        if (num <= 0 || num > RomanBaseNumbers.Item2)
        {
            throw new ArgumentOutOfRangeException();
        }
        StringBuilder sb = new StringBuilder();
        for (int i = RomanBaseNumbers.Item1.Count - 1; i >= 0; i--)
        {
            var current = RomanBaseNumbers.Item1[i];
            if (num >= current.Item2)
            {
                sb.Append(current.Item1);
                num -= current.Item2;
            }
        }
        return sb.ToString();
    }
    static void Main(string[] args)
    {
        for (int i = 1; i <= RomanBaseNumbers.Item2; i++)
        {
            var calc = FromNumberToRoman(i);
            Console.WriteLine("{1}", i, calc);
        }
    }
