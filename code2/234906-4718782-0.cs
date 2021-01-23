        static void Main(string[] args)
        {
            string inputString = @"https://portal.test/sites/test/testabc/Lists/TEST/DispFormSort.aspx?List=36caab7e%2D2234%2D4981%2D8225%%2Easpx";
            
            //TEST CASES:
            //string inputString = @"https://portal.test/sites/test/testabc/Lists/TEST/DispFormSort.aspx?SomeParam=36caab7e%2D2234%2D4981%2D8225%%2Easpx";
            //should return null
            //string inputString = @"https://portal.test/sites/test/testabc/Lists/TEST/DispFormSort.aspx?SomeParam=nih543&List=786yui";
            //should return https://portal.test/sites/test/testabc/Lists/TEST/DispFormSort.aspx?786
            //string inputString = @"https://portal.test/sites/test/testabc/Lists/TEST/DispFormSort.aspx?";
            //should return null
            //string inputString = @"https://portal.test/sites/test/testabc/Lists/TEST/DispFormSort.aspx";
            //should return null
            string result = GetShortenedListURL(inputString);
            Console.WriteLine(result);
            Console.ReadKey();
        }
        private static string GetShortenedListURL(string InputString)
        {
            //Split URL into address and parameter tokens
            var tokens = InputString.Split('?');
            if (tokens.Length > 1)
            {
                var urlParams = tokens[1].Split('&');
                const string listStarter = "LIST=";
                //Loop through parameters looking for one that begins with List
                foreach (var param in urlParams)
                {
                    if (param.ToUpperInvariant().StartsWith(listStarter))
                    {
                        //Found the right parameter, now look for a contiguous string of numbers
                        for (int numCounter = listStarter.Length; numCounter < param.Length; numCounter++)
                        {
                            if (!Char.IsDigit(param[numCounter]))
                            {
                                if (numCounter > listStarter.Length)
                                {
                                    return tokens[0] + "?" + param.Substring(listStarter.Length, numCounter - listStarter.Length);
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
