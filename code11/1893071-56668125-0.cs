    [Cmdlet("Connect", "SomeSystem")]
    public class ConnectCmd : PSCmdlet
    {
        protected override void EndProcessing()
        {
            SessionState.PSVariable.Set(new PSVariable("varName", valueGoesHere, ScopedItemOptions.Private));
        }
    }
