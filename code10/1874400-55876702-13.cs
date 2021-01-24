    public class ClientService : IClientService
    {
        public ClientService(IEntityRepository repository)
        {
            // assuming you have connection string at this point
            repository.SetDbContext("connectionString");
        }
    }
