    string letters = Seperate( "95d",  c => Char.IsLetter( c ) );
    string numbers = Seperate( "95d", c => Char.IsNumber( c ) );
    
    static string Seperate( string input, Func<char,bool> p )
    {
    	return new String( input.ToCharArray().Where( p ).ToArray() );
    }
