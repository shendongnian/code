    const int TIMES = 100_000_000;
    var chrono = new Stopwatch();
    int val = 0;
    
    chrono.Start();
    for ( int i = 1; i <= TIMES; i++ )
    {
      val = ToInt(ToDouble(i));
    }
    chrono.Stop();
    Console.WriteLine(val);
    Console.WriteLine(chrono.ElapsedMilliseconds.ToString());
    chrono.Reset();
    chrono.Start();
    for ( int i = 1; i <= TIMES; i++ )
    {
      var v1 = (double)i;
      val = (int)v1;
    }
    chrono.Stop();
    Console.WriteLine(val);
    Console.WriteLine(chrono.ElapsedMilliseconds.ToString());
    chrono.Reset();
    chrono.Start();
    for ( int i = 1; i <= TIMES; i++ )
    {
      val = i;
    }
    chrono.Stop();
    Console.WriteLine(val);
    Console.WriteLine(chrono.ElapsedMilliseconds.ToString());
