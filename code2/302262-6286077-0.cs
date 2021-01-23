    class Utility
    {
      static readonly string[] BitPatterns ;
      static Utility()
      {
        BitPatterns = new string[256] ;
        for ( int i = 0 ; i < 256 ; ++i )
        {
          char[] chars = new char[8] ;
          for ( byte j = 0 , mask = 0x80 ; mask != 0x00 ; ++j , mask >>= 1 )
          {
            chars[j] = ( 0 == (i&mask) ? '0' : '1' ) ;
          }
          BitPatterns[i] = new string( chars ) ;
        }
        return ;
      }
      
      const int BITS_PER_BYTE = 8 ;
      public static string ToBinaryRepresentation( byte[] bytes )
      {
        StringBuilder sb = new StringBuilder( bytes.Length * BITS_PER_BYTE ) ;
        
        foreach ( byte b in bytes )
        {
          sb.Append( BitPatterns[b] ) ;
        }
        
        string instance = sb.ToString() ;
        return instance ;
      }
      
    }
    class Program
    {
      static void Main()
      {
        byte[] foo = { 0x00 , 0x01 , 0x02 , 0x03 , } ;
        string s   = Utility.ToBinaryRepresentation( foo ) ;
        return ;
      }
    }
