    bool Enable()
    {
        try
        {
            Wrapper.DoStuff();
            Wrapper.DoSomeMoreStuff();
            return true;
        }
        catch(InvalidStatusException)
        {
            Trace.WriteLine("Error");
            return false;
        }
    }
