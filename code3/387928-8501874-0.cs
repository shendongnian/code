    #if !CF
            //[Category("Misc")]
            //[Description("Time to wait for command to execute")]
            //[DefaultValue(30)]
    #endif
            public override int CommandTimeout
            {
                get { return useDefaultTimeout ? 30 : commandTimeout; }
                set 
                {
                    if (commandTimeout < 0)
                        throw new ArgumentException("Command timeout must not be negative");
    
                    // Timeout in milliseconds should not exceed maximum for 32 bit
                    // signed integer (~24 days), because underlying driver (and streams)
                    // use milliseconds expressed ints for timeout values.
                    // Hence, truncate the value.
                    int timeout = Math.Min(value, Int32.MaxValue / 1000);
                    if (timeout != value)
                    {
                        MySqlTrace.LogWarning(connection.ServerThread,
                        "Command timeout value too large ("
                        + value + " seconds). Changed to max. possible value (" 
                        + timeout + " seconds)");
                    }
                    commandTimeout = timeout;
                    useDefaultTimeout = false;
                }
            }
