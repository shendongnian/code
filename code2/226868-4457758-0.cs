    // will return true
    Console.WriteLine( Enum.GetNames(typeof(myen)).Any(member => member.Equals("S3")) );
    Console.WriteLine( Enum.IsDefined(typeof(myen), "S3" ));
    
    // will return false
    Console.WriteLine( Enum.GetNames(typeof(myen)).Any(member => member.Equals("S4")) );
    Console.WriteLine( Enum.IsDefined(typeof(myen), "S4" ));
