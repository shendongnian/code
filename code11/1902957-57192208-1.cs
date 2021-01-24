    public static int NextIntegerInclusive(this Random r, int min_value, int max_value)
    {
      if (max_value < min_value)
      {
        throw new InvalidOperationException("max_value must be greater than min_value.");
      }
      long min = Math.Abs((long)min_value); // e.g. 2,147,483,648
      long max = Math.Abs((long)max_value); // e.g. 2,147,483,647
      long range = min + max + 1; // e.g. 4,294,967,296 (uint.MaxValue + 1)
      return (int) (Math.Round(r.NextDouble() * range) - min); // e.g. -2,147,483,648 => 2,147,483,647
    }
