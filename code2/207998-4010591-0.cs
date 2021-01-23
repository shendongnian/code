    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine( "Reading file..." );
            var sw = Stopwatch.StartNew();
            var counts = new long[ 256 ];
            using ( var input = File.OpenRead( @"c:\Temp\TestFile.dat" ) )
            {
                var buffer = new byte[ 100000 ];
                int bytesRead;
                do
                {
                    bytesRead = input.Read( buffer, 0, buffer.Length );
                    for ( var i = 0; i < bytesRead; i++ )
                        counts[ buffer[ i ] ]++;
                } while ( bytesRead == buffer.Length );
            }
            Console.WriteLine( "Read file in " + sw.ElapsedMilliseconds + "ms" );
            var result = counts.Select( ( c, b ) => new ByteCount { Byte = b, Count = c } )
                .OrderByDescending( x => x.Count );
            foreach ( var byteCount in result )
                Console.WriteLine( byteCount.Byte + " " + byteCount.Count );
        }
        public class ByteCount
        {
            public int Byte { get; set; }
            public long Count { get; set; }
        }
    }
