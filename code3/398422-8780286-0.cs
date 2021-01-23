    public static void Main()
    {
      int[] p = new int[20];
      for (int i = 0; i < 10; i++)
      {
        p[i] = i + 1;
        ¨
        Console.WriteLine(p[i]);
      }
      Dopolni(p);
    
    }
    static void Dopolni(int[] p)
    {
      for (int i = 10; i < 20; i++)
      {
        p[i] = p[i - 10] + p[i - 9];
        Console.WriteLine(p[i]);
      }
    }
