    public class MySubjectClass {
        private readonly Container container;
        
        public MySubjectClass(Container container) {
            this.container = container;
        }
        public async Task AddSignalRConnectionAsync(ConnectionData connection) {
            if (connection != null) {
                var partisionKey = new PartitionKey(connection.ConnectionId);
                await this.container.CreateItemAsync<ConnectionData>(connection, partisionKey);
            }
        }        
    }
    
