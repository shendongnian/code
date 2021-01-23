    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine( ( "02:00:00:001".ToTimeSpan().TotalMilliseconds / "01:00:00:000".ToTimeSpan().TotalMilliseconds ) > 2 );
            Console.WriteLine( ( "02:00:00:001".ToTimeSpan().TotalMilliseconds / "00:60:00:000".ToTimeSpan().TotalMilliseconds ) > 2 );
            Console.WriteLine( ( "02:00:00:000".ToTimeSpan().TotalMilliseconds / "01:00:00:001".ToTimeSpan().TotalMilliseconds ) > 2 );
            Console.WriteLine( ( "25:12:60:002".ToTimeSpan().TotalMilliseconds / "12:12:60:002".ToTimeSpan().TotalMilliseconds ) > 2 );
        }
    }
    public static class Helpers
    {
        public static TimeSpan ToTimeSpan(this string time )
        {
            var split = time.Split( ':' );
            if( split.Length != 4 )
            {
                throw new InvalidOperationException("Invalid format");
            }
            //First posistion is days.
            return new TimeSpan(0, split[ 0 ].ToInt(), split[ 1 ].ToInt(), split[ 2 ].ToInt(), split[ 3 ].ToInt() );
        }
        public static int ToInt( this string str )
        {
            return Convert.ToInt32( str );
        }
    }
