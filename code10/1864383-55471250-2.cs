    public void ErrorEncounter()
    {
        //Global Error Counter
        gblErrorCount++;
        //Process tremination
        ForceExit();
    }
    internal virtual void ForceExit()
    {
        Environment.Exit();
    }
