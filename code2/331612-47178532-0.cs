    public class ArabicToRomanConverter
    {
        private static readonly Dictionary<int, string> _romanDictionary = new Dictionary<int, string>
        {
            {1000,"M"},
            {900,"CM"},
            {500,"D"},
            {400,"CD"},
            {100,"C"},
            {90,"XC"},
            {50,"L"},
            {40,"XL"},
            {10,"X"},
            {9,"IX"},
            {5,"V"},
            {4,"IV"},
            {1 ,"I"}
        };
		
        public ArabicToRomanConverter()
        {
        }
        public string Convert(int arabicNumber)
        {
            StringBuilder romanNumber = new StringBuilder();
            var keys = _romanDictionary.Keys.Where(k => arabicNumber >= k).ToList();
            for (int i = 0; i < keys.Count && arabicNumber > 0; i++)
            {
                int ckey = keys[i];
                int division = arabicNumber / ckey;
                if (division != 0)
                {
                    for (int j = 0; j < division; j++)
                    {
                        romanNumber.Append(_romanDictionary[ckey]);
                        arabicNumber -= ckey;
                    }
                }
            }
            return romanNumber.ToString();
        }
    }
