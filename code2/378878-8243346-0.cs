    public void QueryStatus(string commandName, vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
    {
        if (neededText == vsCommandStatusTextWanted.vsCommandStatusTextWantedNone)
        {
            if (commandName == "MyAddin2.Connect.MyAddin2")
            {
                status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                return;
            }
        }
    }
