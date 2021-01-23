    class ClientHandler : SocketHandler
    {
        private readonly Connection connection;
        private readonly World world;
        public ClientHandler(Connection connection, World world) {
            this.connection = connection;
            this.world = world;
            ...
        }
        //overriden method from SocketHandler
        public override void HandleMessage(Byte[] data) {
            ...
        }
    }
