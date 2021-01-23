    string y = "yyyy-MM-ddTHH':'mm':'sszzz";
    
    string testDate = "1-01-05T00:00:00+00:00".PadLeft(y.Length - 1, '0');
    Console.WriteLine(DateTime.ParseExact(testDate, y, CultureInfo.InvariantCulture));
    testDate = "2011-12-14T15:53:40+00:00".PadLeft(y.Length - 1, '0');
    Console.WriteLine(DateTime.ParseExact(testDate, y, CultureInfo.InvariantCulture));
