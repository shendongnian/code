    public class ClientConnectionFactory : IConnectionFactory
    {
        private readonly World world;
        public ClientConnectionFactory(World world) {
            this.world = world;
        }
        Connection IConnectionFactory.Create(Socket socket) {
            return new ClientConnection(socket, world);
        }
    }
