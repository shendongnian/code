    interface IConnection {
        void Connect();
        void DisConnect();
    }
    class TCPCustomConnection : IConnection{
        // implement other stuff
        // Singleton Pattern
        static IConnection Instance {
            privateInstance = privateInstance ?? new TCPCustomConnection();
            return privateInstance;
        }
    }
