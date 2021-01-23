    internal static string ToLowerCamelCase( this string input )
    {
        string output = "";            
        if( String.IsNullOrEmpty( input ) == false  )
        {
            output = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase( input ); //in case not Title Case
            output = output.Replace( " ", "" ); //remove any white spaces between words
            if( String.IsNullOrEmpty( output ) == false )  //handles the case where input is "  "
            {
                output = char.ToLower( output[0] ) + output.Substring( 1 ); //lowercase first (even if only 1 character string)
            }
        }
        return output;
    }
