    using System.Linq;
    using System.Threading;
    var random = new Random();
    int min = 0;
    int max = 255;
    foreach ( var index in Enumerable.Range(0, 10) )
    {
      var value = random.Next(min, max + 1);
      Console.WriteLine(value);
      Thread.Sleep(100);
    }
