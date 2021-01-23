    private static void better_copy( ushort blockSize )
    {
      if ( blockSize < 1 )  throw new ArgumentOutOfRangeException("blockSize") ;
      
      byte[] input  = File.ReadAllBytes( @"C:\Project1.exe" );   // 16,384 bytes
      byte[] output = new byte[ input.Length] ;
      for ( int p = 0 , n = 0 ; p < input.Length ; p += n )
      {
        int octetsRemaining = input.Length - p ;
        
        n = ( octetsRemaining < blockSize ? octetsRemaining : blockSize ) ;
        
        Array.Copy( input , p , output , p , n ) ;
        
      }
      File.WriteAllBytes( @"C:\blank.exe" , output );
      return ;
    }
