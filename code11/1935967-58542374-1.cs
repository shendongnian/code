    using System.Security.Cryptography;
    using System.Threading;
    ...  
    private static ThreadLocal<Random> MyRandom = new ThreadLocal<Random>(() => {
      int seed;
      using (RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider()) {
        byte[] seedData = new byte[sizeof(int)];
        provider.GetBytes(seedData);
        seed = BitConverter.ToInt32(seedData, 0);
      }
      return new Random(seed);
    });
