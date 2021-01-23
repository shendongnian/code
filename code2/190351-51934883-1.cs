    public static string StripAlpha(this string self)
    {
        return new string( self.Where(c => !Char.IsLetter(c)).ToArray() );
    }
    public static string StripNonNumeric(this string self)
    {
        // Use Vlad's LINQ or the Regex Example
        return new string(self.Where(c=>(Char.IsDigit(c)||c=='.'||c==',')).ToArray()) ;  // See Vlad's
    }
