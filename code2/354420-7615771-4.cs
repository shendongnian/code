    public IExtensions
    {
        void SendToAirbrake(Exception exception);
    }
    public static AirbreakExtensions
    {
        private static IExtensions _impl;
        static()
        {
            impl = new NullExtensions();
            // Todo: Load if available here
        }
        public static void SendToAirbrake(this Exception exception)
        {
            _impl.SendToAirbrake(exception);
        }
    }
    internal class NullExtensions : IExtensions // no-op fake
    {
        void SendToAirbrake(Exception exception)
        {
        }
    }
