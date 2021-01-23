    // => true
    Console.WriteLine( Enum.GetNames(typeof(myen)).Any(member => member.Equals("S3")) );
    Console.WriteLine( Enum.IsDefined(typeof(myen), "S3" ));
    Console.WriteLine( Enum.IsDefined(typeof(myen), 2 ));
    
    // => false
    Console.WriteLine( Enum.GetNames(typeof(myen)).Any(member => member.Equals("S4")) );
    Console.WriteLine( Enum.IsDefined(typeof(myen), "S4" ));
    Console.WriteLine( Enum.IsDefined(typeof(myen), 3 ));
