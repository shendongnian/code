    static void Main(string[] args)
            {
                var days = (new string[] { "3/23/2000", "7/3/2004", "1/3/2004", "3/1/2011" })
                            .Select(a => Convert.ToDateTime(a));
    
                days = days.Select(a => a.AddDays(1 - (a.Day))).Distinct();
                days = days.OrderBy(a => a);
    
                var missingMonths = GetMissingMonths(days).ToList();
            }
    
            private static IEnumerable<DateTime> GetMissingMonths(IEnumerable<DateTime> days)
            {
                DateTime previous = days.First();
                foreach (var current in days.Skip(1))
                {
                    int months = (current.Month - previous.Month) + 
                                        12 * (current.Year - previous.Year);
                    for (int i = 1; i < months; i++)
                    {
                        yield return previous.AddMonths(i);
                    }
                    previous = current;
                }
            }
