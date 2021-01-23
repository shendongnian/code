    public static bool TryParse(
	string s,
	IFormatProvider provider,
	DateTimeStyles styles,
	out DateTime result
    )
    Parameters
    
    s
    Type: System.String
    A string containing a date and time to convert. 
    provider
    Type: System.IFormatProvider
    An object that supplies culture-specific formatting information about s. 
    styles
    Type: System.Globalization.DateTimeStyles
    A bitwise combination of enumeration values that defines how to interpret the parsed date in relation to the current time zone or the current date. A typical value to specify is None.
    result
    Type: System.DateTime%
    When this method returns, contains the DateTime value equivalent to the date and time contained in s, if the conversion succeeded, or MinValue if the conversion failed. The conversion fails if the s parameter is null, is an empty string (""), or does not contain a valid string representation of a date and time. This parameter is passed uni
