      // from 22:00 to midnight and then up to 06:00
      TimeSpan allowedStart = new TimeSpan(22, 00, 00);
      TimeSpan allowedEnd   = new TimeSpan(06, 00, 00);
      
      (DateTime, DateTime)[] tests = new (DateTime, DateTime)[] {
        (new DateTime(2020, 1, 30, 19, 10, 0), new DateTime(2020, 1, 30, 19, 20, 0)),
        (new DateTime(2020, 1, 30, 19, 50, 0), new DateTime(2020, 1, 30, 20, 15, 0)),
        (new DateTime(2020, 1, 30, 20, 10, 0), new DateTime(2020, 1, 30, 20, 35, 0)),
        (new DateTime(2020, 1, 30, 23, 50, 0), new DateTime(2020, 1, 31,  0, 35, 0)),
        (new DateTime(2020, 1, 30, 23, 00, 0), new DateTime(2020, 1, 30, 23, 35, 0)),
        (new DateTime(2020, 1, 30,  3, 00, 0), new DateTime(2020, 1, 30,  4, 00, 0)),
        (new DateTime(2020, 1, 31,  4, 50, 0), new DateTime(2020, 1, 31,  8, 15, 0)),
      };
      Func<DateTime, DateTime, string> within =
        (t1, t2) => $"{(WithinSpan(t1, t2, allowedStart, allowedEnd) ? "Yes" : "No")}";
      string report = string.Join(Environment.NewLine, tests
        .Select(test => $"{test.Item1:yyyy-MM-dd HH:mm:ss} .. {test.Item2:yyyy-MM-dd HH:mm:ss} : {within(test.Item1, test.Item2)}"));
      Console.Write(report);
