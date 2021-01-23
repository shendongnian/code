    private static void Attempt(Action action)
    {
        try { action(); }
        catch (Exception e) {
            Trace.WriteLineIf(ConverterSwitch.TraceVerbose, e);
        }
    }
