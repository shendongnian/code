    if( m.Success )
    {
        Group name = m.Groups["name"];
        Group separator = m.Groups["separator"];
        int index = 0;
        Dictionary<string, string> fields = new Dictionary<string, string>();
        for( int x = 0; x < name.Captures.Count; ++x )
        {
            int separatorIndex = input.Length;
            if( x < separator.Captures.Count )
                separatorIndex = input.IndexOf(separator.Captures[x].Value, index);
            fields.Add(name.Captures[x].Value, input.Substring(index, separatorIndex - index));
            index = separatorIndex + 1;
        }
        // Do something with results.
    }
