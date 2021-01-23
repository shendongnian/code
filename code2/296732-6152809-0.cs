    public static IList<Person> GetListFromNamesAndAges(string[] names, int[] ages)
    {
        if (names.Length != ages.Length)
        {
            throw new ArgumentException("names and ages must be of equal length.");
        }
    
        return new List<Person>(
            names.Select((name, index) =>
                new Person { Name = name, Age = ages[index] }));
    }
    // usage example:
    var persons = GetListFromNamesAndAges(
        new[] {"David", "John"}, 
        new[] {24, 30});
