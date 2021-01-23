    public static class Program
    {
        
        private static CommunicationManager _bcScanner = new CommunicationManager();
        private static ILog _log = LogManager.GetLogger(typeof(Program));
        private static SocketServer socketListener;
