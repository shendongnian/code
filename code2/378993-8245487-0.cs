    public sealed class SendEmailParameters
    {
        public int RepeatCount { get; private set; }
        ...
    }
    private void SendRepeatedlyCallback(object state)
    {
        var parameters = (SendEmailParameters)state;
        // ...
    }
