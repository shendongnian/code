    void SomeFunc(input)
    {
      Do sstuff
    }
    main()
    {
      List<long> results = new List<long>();
      Stopwatch sw = new Stopwatch();
      for(int i = 0; i < MAX_TRIES; i++)
      {
         sw.Start();
         SomeFunc(arg);
         sw.Stop();
         results.Add(sw.ElapsedMilliseconds);
         sw.Reset();
      }
      //Perform analyses and results
    }
