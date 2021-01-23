    using System.Security.Cryptography;
    ...
    public static int GenerateRandomInt(int from, int to)
    {
      byte[] salt = new byte[4];
      RandomNumberGenerator rng = RandomNumberGenerator.Create();
      rng.GetBytes(salt);
      int num = 0;
      for (int i = 0; i < 4; i++)
      {
        num += salt[i];
      }
      return num % (to + 1 - from) + from;
    }
