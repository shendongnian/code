    public static IEnumerable<int> DistributeInteger(double total, int divider)
    {
      if (divider == 0)
      {
        return null;
      }
      else
      {
        var parts = new List<int>();
        var singlePart = total / divider;
        singlePart = Math.Round(singlePart / 100, MidpointRounding.AwayFromZero) * 100;
        while (total - singlePart > 0)
        {
          parts.Add((int)singlePart);
          total -= singlePart;
        }
        // Add remainnig value.
        parts.Add((int)total);
        return parts;
      }
    }
