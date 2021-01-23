    public static string Format(string number, int batchSize, string separator)
    {      
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i <= number.Length / batchSize; i++)
      {
        if (i > 0) sb.Append(separator);
        int currentIndex = i * batchSize;
        sb.Append(number.Substring(currentIndex, 
                  Math.Min(batchSize, number.Length - currentIndex)));
      }
      return sb.ToString();
    }
