    using System.Linq;
    using System.Threading;
    var random = new Random();
    foreach ( var index in Enumerable.Range(0, 10) )
    {
      label12.Text = random.Next(0, 256).ToString();
      Thread.Sleep(100);
    }
