    while (reader.Read())
    {
        sessionInfo.ID = sessionId;
        sessionInfo.Name = reader.IsDBNull( "Name" ) ? null : reader.GetString( "Name" );
        sessionInfo.GroupId = reader.IsDBNull( "GroupId" ) ? null : reader.GetString( "GroupId" );
        sessionInfo.Disabled = reader.IsDBNull( "Disabled" ) ? false : reader.GetBoolean( "Disabled" );
        // etc...
