    private static Regex rxBogusPhoneNumber = new Regex( @"^(?<digit>\d)\k<digit>+$" ) ;
    public static bool isBogusPhoneNumber( string phoneNumber )
    {
      return rxBogusPhoneNumber.IsMatch( phoneNumber ) ;
    }
