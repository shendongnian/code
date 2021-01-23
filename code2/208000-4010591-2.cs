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
            var frequency = new long[ 256 ];
            using ( var input = File.OpenRead( @"c:\Temp\TestFile.dat" ) )
            {
                var buffer = new byte[ 100000 ];
                int bytesRead;
                do
                {
                    bytesRead = input.Read( buffer, 0, buffer.Length );
                    for ( var i = 0; i < bytesRead; i++ )
                        frequency[ buffer[ i ] ]++;
                } while ( bytesRead == buffer.Length );
            }
            Console.WriteLine( "Read file in " + sw.ElapsedMilliseconds + "ms" );
            var result = frequency.Select( ( f, i ) => new ByteFrequency { Byte = i, Frequency = f } )
                .OrderByDescending( x => x.Frequency );
            foreach ( var byteCount in result )
                Console.WriteLine( byteCount.Byte + " " + byteCount.Frequency );
        }
        public class ByteFrequency
        {
            public int Byte { get; set; }
            public long Frequency { get; set; }
        }
    }
