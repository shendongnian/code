    public static string GetRandomString(int length)
    {
      var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
      var random = new Random();
      var result = new string(
        Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)])
          .ToArray());
      return result;
    }
