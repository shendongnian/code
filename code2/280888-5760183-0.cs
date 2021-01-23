    private static Regex rxLongWord = new Regex( @"\w{50,}" ) ;
    public HasLongWord( string s )
    {
      bool foundLongWord = rxLongWord.IsMatch( s ) ;
      return foundLongWord ;
    }
