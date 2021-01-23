    private static readonly char[] _base62Characters = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    public static string ToBase62String( long value )
    {
        if( value < 0L )
        {
            throw new ArgumentException( "Number must be zero or greater." );
        }
        if( value == 0 )
        {
            return "0";
        }
        string retVal = "";
        while( value > 0 )
        {
            retVal = _base62Characters[value % 62] + retVal;
            value = value / 62;
        }
        return retVal;
    }
