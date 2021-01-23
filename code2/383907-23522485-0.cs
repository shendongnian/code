    public static void PrintKeysAndValues2( NameValueCollection myCol )
    {
        Console.WriteLine( "   [INDEX] KEY        VALUE" );
        for ( int i = 0; i < myCol.Count; i++ )
            Console.WriteLine( "   [{0}]     {1,-10} {2}", i, myCol.GetKey(i), myCol.Get(i) );
        Console.WriteLine();
    }
