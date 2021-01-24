      var stopwatch = new Stopwatch();
      stopwatch.Start();
      while (true) //Your condition
      {
        if (stopwatch.Elapsed == TimeSpan.FromSeconds(10))
        {
          Console.WriteLine(stopwatch.ElapsedMilliseconds);
          Console.WriteLine("Do Func();"); //Call your function
          stopwatch.Reset();
          stopwatch.Start();
        }
      }
