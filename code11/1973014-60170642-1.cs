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
**EDIT**
You might want to read up on `await` vs `Wait()`. I did imply by you saying the program continues sequentially that you are in purely synchronous context and just need to improve fetching performance. But if you call this Code from a UI Thread or similar beware that the `Wait()` call will block your UI thread. In this case using await would be the better option. (https://stackoverflow.com/questions/13140523/await-vs-task-wait-deadlock)
