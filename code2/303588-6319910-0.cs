    private static bool ProcessLine(string line)
    {
        try
        {
            var sampleSections = splitTheSampleIntoAListOfStrings();
            foreach( var sampleSection in line )
            {
                DoSomeStuff();
            }
            return true;
        }
        catch( SomeException ex )
        {
            LogError(ex);
            return false;
        }
    }
    private static void ProcessSamples(FlightType flight)
    {
        var samples = GetRawGPSDataIntoAString(flight);
        foreach( var line in samples )
        {
            if( !ProcessLine(line) )
                return;
        }
    }
    private static void ProcessFlights()
    {
        foreach( var flight in flightList )
        {
            ProcessSamples(flight);
        }
    }
