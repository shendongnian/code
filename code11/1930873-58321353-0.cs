using System.Threading;
    void reset(ref bool a, float b)
    {
      Thread.Sleep(Convert.ToInt32(b));
      a = true;
    }
Usage:
    static void Test()
    {
      var b = false;
      reset(ref b, 2000.30f);
      Console.WriteLine(b.ToString());
    }
Output:
    True
