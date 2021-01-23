    public static class Program
        {
            private static ILog _log = LogManager.GetLogger(typeof(Program));
            private static CommunicationManager _bcScanner = new CommunicationManager();
            private static SocketServer socketListener;
