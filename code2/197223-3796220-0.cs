    static void Test()
    {
      var random = new Random(10);
      var alphabet = "abcdefghijklmnopqrstuvwxyz";
      var content = new String((from x in Enumerable.Range(0, 10000000)
                                select a[random.Next(0, a.Length)]).ToArray());
      var searchString = content.Substring(5000000, 4096);
      var regex = new Regex(searchString);
      var sw = Stopwatch.StartNew();
      for (int i = 0; i < 1000; i++)
      {
        if (!regex.IsMatch(content))
        {
          throw new Exception();
        }
      }
      sw.Stop();
      Console.WriteLine("Regex: " + sw.Elapsed);
      sw.Restart();
      for (int i = 0; i < 1000; i++)
      {
        if (!content.Contains(searchString))
        {
          throw new Exception();
        }
      }
      sw.Stop();
      Console.WriteLine("String.Contains: " + sw.Elapsed);
    }
