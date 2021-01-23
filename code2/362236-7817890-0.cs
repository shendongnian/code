    string[] TrimAll( string[] input )
    {
        var result = new List<string>();
        foreach( var s in input )
            result.Add( s.Trim() );
        }
        return result.ToArray();
    }
    var delimiters = new [] { ",", "\t", Environment.NewLine };
    string result = string.Join(",", TrimAll( input.Split( delimiters, StringSplitOptions.RemoveEmptyEntries ) ) );
