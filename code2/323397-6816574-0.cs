    public class WorkerFactory
    {
        private readonly IClientMessagesRepo clientMessagesRepo;
        public WorkerFactory(IClientMessagesRepo clientMessagesRepo)
        {
            this.clientMessagesRepo = clientMessagesRepo;
        }
    
        public Worker Create(IClient client)
        {
            return new Worker(client, clientMessagesRepo);
        }
    }
