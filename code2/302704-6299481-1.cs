    static IEnumerable<double?> GetChanges(IEnumerable<double?> x)
    {
        double? previous = x.First();
        return x.Skip(1).Select(d =>
                  { double? result = d - previous; previous = d; return result; });
    }
