                public class IPValidator
                {
                    public static IPValidator Parse(string input)
                    {
                        Regex regexpr = new Regex(@" ");
                        Match match = regexpr.Match(input);
                        if (match.Success)
                            return new IPValidator();
                        else throw new ArgumentException(input);
                    }
                }
