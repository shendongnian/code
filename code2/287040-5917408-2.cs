    static void Main( string[] args )
    {
      byte[][] testcases = { new byte[]{0x00,0x00,0x00,0x01,} ,
                             null                   ,
                             new byte[]{0x7F,0xFF,0xFF,0xFF,} ,
                           } ;
      
      foreach ( byte[] bytes in testcases )
      {
          int? x =  Bytes2IntViaSQL( bytes ) ;
          if ( x.HasValue ) Console.WriteLine( "X is {0}" , x ) ; 
          else              Console.WriteLine( "X is NULL" ) ;
      }
      
      return ;
    }
