    char[] splitter = new char[1];
    splitter[0] = ' ';
    
    while( readLines into String )
    {
       _logEntries.Add( new LogEntry( String.Split( splitter ) ) );
    }
