    public static class Extensions
    {
       public static int RoundTo(this int source, params int[] values) 
          => values.OrderBy(x => x).First(x => x >= source);
    }
