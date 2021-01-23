    public string MergeStrings(params string[] strings)
    {
        var stringBuilder = new StringBuilder();
    
        foreach(var s in strings)
        {
            stringBuilder.Append( s.Replace( "|", "||" ) );
            stringBuilder.Append( " | " );
        }
    
        return stringBuilder.ToString();
    }
    
    public IEnumerable<string> SplitString(string stringToSplit)
    {
        var results = stringToSplit.Split( new[] { " | " }, StringSplitOptions.RemoveEmptyEntries );
    
        return results.Select( result => result.Replace( "||", "|" ) );
    }
