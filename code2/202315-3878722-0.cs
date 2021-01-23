    public static double? FirstOrNull(this IEnumerable<double> items)
    {
        foreach(double item in items)
            return item;
        return null;
    } 
