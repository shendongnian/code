    static void Main( string[] args )
    {
      int a1 = 123456;
      int a2 = 654321;
      int a3;
      var t = new System.Diagnostics.Stopwatch();
      t.Start();
      for ( int i = 0; i < int.MaxValue; i++ )
      {
        if ( a1 == a2 )
        {
          a3 = a1 + a2;
        }
      }
      t.Stop();
      Console.WriteLine( t.ElapsedMilliseconds );
      t.Reset();
      t.Start();
      for ( int i = 0; i < int.MaxValue; i++ )
      {
        if ( ( a1 ^ a2 ) == 0 )
        {
          a3 = a1 + a2;
        }
      }
      t.Stop();
      Console.WriteLine( t.ElapsedMilliseconds );
      Console.ReadKey();
    }
