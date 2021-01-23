    class Program
    {
        private static ISet<string> _currencySymbols = new HashSet<string>() { "$", "zł", "€", "£" };
        private static bool StringIsCurrency(string str)
        {
            // Scan the beginning of the string until you get to the first digit
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    if (i == 0)
                    {
                        break;
                    }
                    else
                    {
                        return StringIsCurrencySymbol(str.Substring(0, i).TrimEnd());
                    }
                }
            }
            // Scan the end of the string until you get to the last digit
            for (int i = 0, pos = str.Length - 1; i < str.Length; i++, pos--)
            {
                if (char.IsDigit(str[pos]))
                {
                    if (i == 0)
                    {
                        break;
                    }
                    else
                    {
                        return StringIsCurrencySymbol(str.Substring(pos + 1, str.Length - pos - 1).TrimStart());
                    }
                }
            }
            // No currency symbol found
            return false;
        }
        private static bool StringIsCurrencySymbol(string symbol)
        {
            return _currencySymbols.Contains(symbol);
        }
        static void Main(string[] args)
        {
            Test("$1000.00");
            Test("500 zł");
            Test("987");
            Test("book");
            Test("20 €");
            Test("99£");
        }
        private static void Test(string testString)
        {
            Console.WriteLine(testString + ": " + StringIsCurrency(testString));
        }
    }
