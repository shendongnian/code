    [Flags]
    public enum Result
    {
      None = 1,
      Warning = 2,
      Error = 4,
      Success = 8,
      Failure = 16
    }
    ublic void ProcessResultValues(string log)
    {
      var resultFlags = new List<Result>();
      // For test
      resultFlags.Add(Result.Warning);
      resultFlags.Add(Result.Success);
      Result results = default(Result);
      resultFlags.ForEach(value => results |= value);
      ReportResults(results);
    }
    ublic void ReportResults(Result results)
    {
      // For test
      foreach ( Enum value in Enum.GetValues(typeof(Result)) )
        if ( results.HasFlag(value) )
          Console.WriteLine(value);
    }
