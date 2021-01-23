    public static class Coolifier
    {
      public static void BeCool<A,B>(params A[] a, params B[] b)
      {
      }
    }
    
    Coolifier.BeCool<string,string> ("I", "don't", "work.", "DO", "I", "?");
