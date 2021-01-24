    public static Dictionary<String,String> CreateLookupDictionary(String input)
    {
        Debug.WriteLine(input);
        return input
            .Split( _splitOnLines , StringSplitOptions.RemoveEmptyEntries )
            .Select( line => line.Split( _splitHeader, StringSplitOptions.None ) )
            .Select( arr => ( name: arr[0], value: arr[1] ) )
            .Aggregate(
                new Dictionary<String,String>( StringComparer.InvariantCultureIgnoreCase ),
                ( d, header ) =>
                {
                    d[ header.name ] = header.value;
                    return d;
                }
            );
    }
