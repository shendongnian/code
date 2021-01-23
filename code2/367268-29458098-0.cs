    enum Elvis
    {
      Instance
    }
    static class ElvisExtension
    {
      private static readonly string[] FavoriteSongs = { "Hound Dog", "Heartbreak Hotel" };
    
      public static void PrintFavorites(this Elvis singleton)
      {
        Console.WriteLine(string.Join(", ", FavoriteSongs));
      }
    }
