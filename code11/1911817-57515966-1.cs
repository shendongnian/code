    static class Extensions 
    {
      public static bool HasAnyChannel(
          this Channel x,
          Channel y) =>
        x & y != Channel.None;
    }
