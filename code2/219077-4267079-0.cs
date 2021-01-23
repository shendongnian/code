    Dictionary<string, SqlDbType> columnDefinition = new Dictionary<string, SqlDbType>( )
    {
        { "S.No", SqlDbType.YourType },
        { "Name", SqlDbType.OtherType }
    };
    private void AddParams( SqlCeCommand cmd, params string[] cols )
    {
        foreach( string col in cols )
        {
           cmd.Parameters.Add( "@" + col, columnDefinition[ col ], 0, col );
        }
    }
