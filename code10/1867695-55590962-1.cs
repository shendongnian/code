    Console.WriteLine( "Enter your password" );
    SecureString password = new SecureString();
    while( Char c = Console.ReadKey() != '[Enter'] ) {
        password.Append( c );
    }
