    public ExtensionsAdapter : IExtensions
    {
        void SendToAirbrake(Exception exception)
        {
            SharpBrake.Extensions.SendToAirbrake(exception);
        }
    }
