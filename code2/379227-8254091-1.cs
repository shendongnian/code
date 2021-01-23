    class Program
    {
        static void Main( string[] args )
        {
            string s1 = "1.25";
            string s2 = "1.256";
            string s3 = "1.2";
            
            decimal d1 = decimal.Parse( s1 );
            decimal d2 = decimal.Parse( s2 );
            decimal d3 = decimal.Parse( s3 );
            
            Console.WriteLine( d1 * 100 - (int)( d1 * 100) == 0);
            Console.WriteLine( d2 * 100 - (int)( d2 * 100)  == 0);
            Console.WriteLine( d3 * 100 - (int)( d3 * 100 ) == 0 );
        }
    }
