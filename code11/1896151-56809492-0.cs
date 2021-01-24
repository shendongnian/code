    // Using cached static fields to avoid unnecessary array allocation:
    static readonly String[] _splitOnLines = new String[] { "\r\n" };
    static readonly String[] _splitHeader  = new String[] { ": " };
    public static Dictionary<String,String> CreateLookupDictionary(String input)
    {
        Debug.WriteLine(input);
        return input
            .Split( _splitOnLines , StringSplitOptions.RemoveEmptyEntries )
            .Select( line => line.Split( _splitHeader, StringSplitOptions.None ) )
            .Select( arr => ( name: arr[0], value: arr[1] ) ) // using C# 7 named tuples for maintainability
            .GroupBy( header => header.name )
            .Select( duplicateHeaderGroup => duplicateHeaderGroup.Last() )
            .ToDictionary( header => header.name, header.value, StringComparer.InvariantCultureIgnoreCase );
    }
