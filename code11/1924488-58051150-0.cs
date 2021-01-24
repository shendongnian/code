    static void Main(string[] args)
    {
      var list = new SortedSet<int>();
      int count = 5;
      for ( int i = 0; i < count; i++ )
        list.Add(Convert.ToInt32(Console.ReadLine()));
      foreach (int item in list)
        Console.WriteLine(item);
      Console.ReadKey();
    }
