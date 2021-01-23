    static void Main(string[] args)
            {
                string source = "HTTP test [17] 20110515150601.log";
                Regex regex = new Regex(@"(\d{8})\d*\.log");
                var match = regex.Match(source);
                if (match.Success)
                {
                    DateTime date;
                    if (DateTime.TryParseExact(match.Groups[1].Value, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    {
                        Console.WriteLine("Parsed date to {0}", date);
                    }
                    else
                    {
                        Console.WriteLine("Could not parse date");
                    }
                }
                else
                {
                    Console.WriteLine("The input is not a match.");
                }
                Console.ReadLine();
            }
