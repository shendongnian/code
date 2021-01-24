    while( true )
    {
        Console.Write( "Enter number: " );
        String input = Console.ReadLine();
        if( Int32.TryParse( input, out Int32 value ) ) // ideally use the overload with NumberStyles.Any and CultureInfo.CurrentCulture to be explicit.
        {
            Console.WriteLine( $"Output: {value}" );
        }
        else
        {
            Console.WriteLine( "Please enter a valid number." ); 
        }
    }
    
