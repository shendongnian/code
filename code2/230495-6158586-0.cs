    public class MsoCrc32
    {
      private const int BUFFER_SIZE =  4096 ;
      private static readonly uint[] cache ;
      public uint Value { get ; private set ; }
      public void Add( byte[] bytes )
      {
        foreach ( byte octet in bytes )
        {
          uint i = ( Value >> 24 ) ^ octet ;
          Value <<= 8        ;
          Value  ^= cache[i] ;
        }
        return ;
      }
      public void Add( Stream s )
      {
        byte[] buffer = new byte[BUFFER_SIZE] ;
        int    bufl   = 0 ;
        while ( (bufl=s.Read(buffer,0,buffer.Length)) > 0 )
        {
          Add( buffer ) ;
        }
        return ;
      }
      public MsoCrc32() : this(0)
      {
      }
      public MsoCrc32( int value )
      {
        this.Value = (uint) value ;
      }
      static MsoCrc32()
      {
        cache = InitCache();
        return ;
      }
      private static uint[] InitCache()
      {
        uint[] cacheInstance = new uint[256] ;
        
        for ( uint i = 0 ; i < cache.Length ; ++i )
        {
          uint value = i << 24 ;
          
          for ( uint j = 0 ; j < 8 ; ++j )
          {
            value <<= 1 ;
            if ( 0x80000000 == (value&0x80000000) )
            {
              value  ^= 0xAF000000 ;
            }
          }
          
          value &= 0xFFFF0000 ;
          
          cacheInstance[i] = value ;
          
        }
        
        return cacheInstance ;
      }
    
    }
