    PrintStrings( "myMessage"  );
    public static void PrintStrings( string message )
    {
        AcutallyDoSomething( message );
    }
    public static void PrintStrings( List<String> messages )
    {
       foreach ( String message in messages )
       {
          AcutallyDoSomething( message );
       }
       //Do other things
    }
    
    private static void AcutallyDoSomething(string msg)
    {
       foreach ( String message in messages )
       {
          Console.WriteLine( message );
       }
    }
