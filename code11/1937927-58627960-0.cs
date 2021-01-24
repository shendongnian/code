    const int TIMES = 100_000_000;
    var chrono = new Stopwatch();
    chrono.Start();
    for ( int i = 0; i < TIMES; i++ )
    {
      var val = ToInt(ToDouble(i));
    }
    chrono.Stop();
    Console.WriteLine(chrono.ElapsedMilliseconds.ToString());
    chrono.Start();
    for ( int i = 0; i < TIMES; i++ )
    {
    }
    chrono.Stop();
    Console.WriteLine(chrono.ElapsedMilliseconds.ToString());
