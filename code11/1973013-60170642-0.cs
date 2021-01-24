  class Program
  {
    static void Main()
    {
      Task<List<int>> t1 = new Task<List<int>>(GetList);
      Task<List<int>> t2 = new Task<List<int>>(GetList);
      t1.Start();
      t2.Start();
      Task.WhenAll(t1, t2).Wait();
      Console.WriteLine("Both should have ended now");
      List<int> lst1 = t1.Result;
      List<int> lst2 = t2.Result;
      Console.ReadKey(true);
    }
    public static List<int> GetList()
    {
      Console.WriteLine("Started");
      Random rng = new Random();
      List<int> lst = new List<int>();
      for(int i = 0; i < 1000000; i++)
      {
        lst.Add(rng.Next());
      }
      Console.WriteLine("Ended");
      return lst;
    }
  }
