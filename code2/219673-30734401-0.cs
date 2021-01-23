    public static IEnumerable<ulong> Range(ulong fromInclusive, ulong toExclusive)
    {
      for (var i = fromInclusive; i < toExclusive; i++) yield return i;
    }
    
    public static void ParallelFor(ulong fromInclusive, ulong toExclusive, Action<ulong> body)
    {
      Parallel.ForEach(
         Range(fromInclusive, toExclusive),
         new ParallelOptions { MaxDegreeOfParallelism = 4 },
         body);
    }
