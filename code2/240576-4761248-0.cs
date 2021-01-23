    byte[] myBytes = new byte[5] { 1, 2, 3, 4, 5 };
    BitArray myBA3 = new BitArray( myBytes );
    Console.WriteLine( "myBA3" );
    Console.WriteLine( "   Count:    {0}", myBA3.Count );
    Console.WriteLine( "   Length:   {0}", myBA3.Length );
    Console.WriteLine( "   Values:" );
    PrintValues( myBA3, 8 );
    public static void PrintValues( IEnumerable myList, int myWidth )
    {
       int i = myWidth;
       foreach ( Object obj in myList )
       {
          if ( i <= 0 )
          {
             i = myWidth;
             Console.WriteLine();
          }
          i--;
          Console.Write( "{0,8}", obj );
       }
       Console.WriteLine();
    }
