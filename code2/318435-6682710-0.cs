    public class MessageHandler
    {
        private readonly Func<Connection> connectionProvider;
        public MessageHander(Func<Connection> connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }
        public void WriteMessage(string message)
        {
            using (Connection connection = connectionProvider.Invoke())
            {
                connection.DoSomething(message);
            }
        }
    }
