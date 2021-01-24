    class Program
      {
        static void Main(string[] args)
        {
          Tuple<int, int> height = GetHeight();
    
          Console.WriteLine(height.Item1 + " - " + height.Item2);
          Console.ReadLine();
        }
    
        private static Tuple<int, int> GetHeight()
        {
          return new Tuple<int, int>(2, 3);
        }
      }
