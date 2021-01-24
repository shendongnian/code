      TimeSpan allowedStart = new TimeSpan(08, 00, 0);
      TimeSpan allowedEnd = new TimeSpan(20, 00, 0);
      (DateTime, DateTime)[] tests = new (DateTime, DateTime)[] {
        (new DateTime(2020, 1, 30, 19, 10, 0), new DateTime(2020, 1, 30, 19, 20, 0)),
        (new DateTime(2020, 1, 30, 19, 50, 0), new DateTime(2020, 1, 30, 20, 15, 0)),
        (new DateTime(2020, 1, 30, 20, 10, 0), new DateTime(2020, 1, 30, 20, 35, 0)),
        (new DateTime(2020, 1, 30, 23, 50, 0), new DateTime(2020, 1, 31,  0, 35, 0)),
        (new DateTime(2020, 1, 31,  7, 50, 0), new DateTime(2020, 1, 31,  8, 15, 0)),
      };
      Func<DateTime, DateTime, string> within = 
        (t1, t2) => $"{(WithinSpan(t1, t2, allowedStart, allowedEnd) ? "Yes" : "No")}";
      string report = string.Join(Environment.NewLine, tests
        .Select(test => $"{test.Item1:yyyy-MM-dd HH:mm:ss} .. {test.Item2:yyyy-MM-dd HH:mm:ss} : {within(test.Item1, test.Item2)}"));
 
      Console.Write(report);
