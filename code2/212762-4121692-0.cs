    while (true)
    {
      Stopwatch watch = new Stopwatch();
      watch.Start();
      Int64 myNum = 123456789;
      for (int i = 0; i < 10000000; i++)
      {
        myNum++;
        DoSomething(myNum);
      }
      watch.Stop();
      Console.WriteLine("Time: " + watch.ElapsedMilliseconds + "ms");
    }
    private void DoSomething(Int64 bigNum)
    {
      Int64 fake = bigNum - 1;
    }
