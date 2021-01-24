    static void Main(string[] args)
        {
          int lower = 2;
          int upper = 10;
          int step = -2;
    
          if (Math.Sign(step) == 1)
          {
            for (int i = step; i < upper; i += step)
            {
              Console.WriteLine(string.Format("{0}", i));
            }
          }
          else
          {
            for (int i = upper; i >= lower; i += step)
            {
              Console.WriteLine(string.Format("{0}", i));
            }
          }
          Console.ReadLine();
        }
      }
