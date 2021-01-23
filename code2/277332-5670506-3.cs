    using System.IO  ;
    using Ionic.Zlib ;
    namespace ZlibExample
    {
        class Program
        {
            static void Main( string[] args )
            {
                using ( Stream     compressed = File.OpenRead( @"c:\foobar.zlib" ) )
                using ( ZlibStream zlib       = new ZlibStream( compressed , CompressionMode.Decompress ) )
                {
                    byte[] buf  = new byte[short.MaxValue] ;
                    int    bufl ;
                    while ( 0 != (bufl=zlib.Read(buf,0,buf.Length) ) )
                    {
                       DoSomethingWithDecompressedData( buf , bufl ) ;
                    }
                }
                return ;
            }
        }
    }
