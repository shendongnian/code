    class Program
    {
        static void Main(string[] args)
        {
            var processedText = Regex.Replace("Some text [first_name | User] some other text. [Your birthday is on yy / mm / dd | ]. " +
                "Dear [ first_name | User ], How are you?. [ Your birthday is on yy/mm/dd | ]",
                @"\[\s*(.*?)\s*\|\s*(.*?)\s*\]", new MatchEvaluator(ReplaceAction));
            Console.WriteLine(processedText);
        }
        public static bool DummyTryGetValueFromDb(string key, out string value)
        {
            Random randomizer = new Random(DateTime.UtcNow.Millisecond);
            if (randomizer.Next(100) > 50) // Successfully found in db :)
            {
                if (key == "first_name")
                {
                    value = "Toto";
                    return true;
                }
                else
                {
                    value = "Your birthday is on your birthday date from db !";
                    return true;
                }
            }
            else
            {
                value = string.Empty;
                return false;
            }
        }
        public static string ReplaceAction(Match match)
        {
            if (match.Groups.Count > 1)
            {
                var dataKeyGroup = match.Groups[1];
                if (DummyTryGetValueFromDb(dataKeyGroup.Value, out var valueFromDb))
                    return valueFromDb;
                else if (match.Groups.Count > 2)
                    return match.Groups[2].Value;
                else
                    return "[Not found from db, no alternative value]"; // you can throw exception
            }
            else
                return "[Bad syntax]"; // you can throw exception
        }
    }
