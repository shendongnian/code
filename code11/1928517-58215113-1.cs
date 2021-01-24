    Tuple<string, string>[] tests = new[] {
      Tuple.Create("間違う", "ま|ちが|#"),
      Tuple.Create("立ち上げる", "た|#|あ|#|#"),
      Tuple.Create("取る", "と|#"),
    };
    var result = string.Join(Environment.NewLine, tests
      .Select(test => 
         $"{test.Item1,5} + {test.Item2,10} => {ProcessString(test.Item1, test.Item2)}"));
    Console.WriteLine(result);
