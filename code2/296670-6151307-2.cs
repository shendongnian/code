    var searchPattern = @"*.xls";
    var limits = new[] { 5, 10, 15, 20 }; // assuming you're going in 5K increments
    var counts = new int[limits.Length];
    foreach (var fi in di.EnumerateFiles(searchPattern))
                       // or use GetFiles() if you're not targeting .NET 4.0
    {
        for (int i = 0; i < limits.Length; i++)
            if (fi.Length <= limits[i] * 1024)
                counts[i]++;
    }
    if (counts[0] > 0)
    {
        dest.WriteLine("Excel File <= {0} KB", limits[0]);
        dest.WriteLine(counts[0]);
        dest.WriteLine();
    }
    for (int i = 1; i < limits.Length; i++)
    {
        if (counts[i] > 0)
        {
            dest.WriteLine("Excel File > {0} KB and <= {1} KB", limits[i - 1], limits[i]);
            dest.WriteLine(counts[i]);
            dest.WriteLine();
        }
    }
