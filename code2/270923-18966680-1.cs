    var commandLine = Environment.CommandLine;
    var argumentsString = "";
    if(args.Length > 0)
    {
        // Re-escaping args to be the exact same as they were passed is hard and misses whitespace.
        // Use the original command line and trim off the executable to get the args.
        var argIndex = -1;
        if(commandLine[0] == '"')
        {
            //Double-quotes mean we need to dig to find the closing double-quote.
            var backslashPending = false;
            var secondDoublequoteIndex = -1;
            for(var i = 1; i < commandLine.Length; i++)
            {
                if(backslashPending)
                {
                    backslashPending = false;
                    continue;
                }
                if(commandLine[i] == '\\')
                {
                    backslashPending = true;
                    continue;
                }
                if(commandLine[i] == '"')
                {
                    secondDoublequoteIndex = i + 1;
                    break;
                }
            }
            argIndex = secondDoublequoteIndex;
        }
        else
        {
            // No double-quotes, so args begin after first whitespace.
            argIndex = commandLine.IndexOf(" ", System.StringComparison.Ordinal);
        }
        if(argIndex != -1)
        {
            argumentsString = commandLine.Substring(argIndex + 1);
        }
    }
    Console.WriteLine("argumentsString: " + argumentsString);
