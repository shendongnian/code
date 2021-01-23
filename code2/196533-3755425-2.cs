    string WalkIt( Dictionary<string,object> data )
    {
        if ( data == null ) yield return null;
        foreach (KeyValuePair<string, object> kvp in data)
        {
            if (kvp.Value is string)
            {
                yield return kvp.Value;
            }
            if (kvp.Value is Dictionary<string, object>)
            {
                foreach( string str in walk(kvp.Value as Dictionary<string, object>))
                     yield return str;
            }
                }
            }
           yield return null;
    }
