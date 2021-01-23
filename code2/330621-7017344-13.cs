    class ClientNotifier : IMovementNotifier //, ..., + bunch of other notifiers
    {
        private readonly Connection connection;
         
        public ClientHandler(Connection connection) {
            this.connection = connection;
        }
        void IMovementNotifier.Move(Player player, Location destination) {
            ...
            connection.Send(new MoveMessage(...));
        }
    }
