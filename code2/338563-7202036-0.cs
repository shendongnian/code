    class Program
    {
      public static string timeTaken;
      static void Main(string[] args)
      {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(firstline);
        System.Diagnostics.Stopwatch timer = new Stopwatch();
        timer.Start();
        using (var response = request.GetResponse())
        timer.Stop();
        timeTaken = timer.Elapsed.ToString();
      }
    }
