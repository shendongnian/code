    IDictionary<string,string> DictionaryOfStringFromErrorInfo( string s,
        DeviceInfo deviceInfo, Exception ex )
    {
        Dictionary<string,string> dictionary = new Dictionary<string, string>();
        dictionary.Add( "RunQuery", "Exception" );
        List<string> parts = s.ConvertToChunkList(125);
        dictionary.Add( "Device Model", DeviceInfo.Model );
        dictionary.Add( "Exception", ex.ToString() );
        for( int i = 0;  i < parts.Count;  i++ )
            dictionary.Add( "Sql" + i, parts[i] );
        return dictionary;
    }
