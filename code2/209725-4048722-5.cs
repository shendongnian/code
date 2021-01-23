    public class PopulationTotal
    {
        // You can use subclassing instead of an enum to represent this
        public enum Kind
        { RunningTotalWithinCountry, TotalForCountry, TotalOverall }
    
        public string GroupName { get; private set; }
        public int Value { get; private set; }
        public Kind Kind { get; private set; }
    
        public static IEnumerable<PopulationTotal> GetTotals(IEnumerable<Element> elements)
        {
            int overallTotal = 0;
    
            foreach (var elementsByCountry in elements.GroupBy(e => e.Country))
            {
                int runningTotalForCountry = 0;
    
                foreach (var element in elementsByCountry)
                {
                    runningTotalForCountry += element.Population;
                    yield return new PopulationTotal
                                        {
                                            GroupName = element.City,
                                            Kind = Kind.RunningTotalWithinCountry,
                                            Value = runningTotalForCountry
                                        };
                }
    
                overallTotal += runningTotalForCountry;
    
                yield return new PopulationTotal
                                    {
                                        GroupName = elementsByCountry.Key,
                                        Kind = Kind.TotalForCountry,
                                        Value = runningTotalForCountry
                                    };
            }
    
            yield return new PopulationTotal
                                {
                                    GroupName = null,
                                    Kind = Kind.TotalOverall,
                                    Value = overallTotal
                                };
        }
    }
