    static void Main()
    {
        // Demo data
        myClass[] myPa = new myClass[2];
        myPa[0] = new myClass();
        myPa[0].S = "1";
        myPa[0].I = 0;
        myPa[1] = new myClass();
        myPa[1].S = "12";
        myPa[1].I = 1;
        PrintMaxLengthsOfStringProperties(myPa);
    }
    public static void PrintMaxLengthsOfStringProperties<T>(IEnumerable<T> items)
    {
        var t = typeof(T);
        t.GetProperties().Where(p => p.PropertyType == typeof(string)) // TODO: Add other filters
                            .SelectMany(p => items.Select(o => (string)p.GetValue(o, null)).Select(v => new { Property = p, Value = v }))
                            .GroupBy(u => u.Property)
                            .Select(gu => new { Property = gu.Key, MaxLength = gu.Max(u => u.Value != null ? u.Value.Length : 0) })
                            .ToList()
                            .ForEach(u2 => Console.WriteLine("Property: {0}, Biggest Size: {1}", u2.Property.Name, u2.MaxLength))
                            ;
    }
