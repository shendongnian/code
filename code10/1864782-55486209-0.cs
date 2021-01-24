    string serialNumber = System.IO.File.ReadLines(@"D:\Sample.txt")
    .Select(line =>
    {
        var match = System.Text.RegularExpressions.Regex.Match(line, @"^\[""(.*)""\]$");
        return match.Success ? match.Groups[1].Value : null;
    }).FirstOrDefault(sn => sn != null);
