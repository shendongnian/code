    private static Random random;
    private static object syncObj = new object();
    private static void InitRandomNumber(int seed)
    {
         random = new Random(seed);
    }
    private static int GenerateRandomNumber(int max)
    {
         lock(syncObj)
         {
             if (random == null)
                 random = new Random(); // Or exception...
             return random.Next(max);
         }
    }
