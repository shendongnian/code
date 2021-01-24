    static class Program
    {
      static Random random = new Random(255);
      static void Main(string[] args)
      {
        int posX = random.Next(0, 255);
        int posY = random.Next(0, 255);
        ...
      }
    }
