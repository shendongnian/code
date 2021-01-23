    public class ClientRepository
    {
        public ClientRepository()
        {
            this.DataContext = new HydraDataContext();
        }
        private HydraDataConetxt DataContext { get; set; }
        // DBResult is a made up class which returns some info about the operation...
        public DBResult Insert(Client client)
        {
            try
            {
                this.DataContext.Clients.InsertOnSubmit(client);
                this.DataContext.SubmitChanges();
                 return DBResult.Success;
            }
            catch (Exception error)
            {
                 return DBResult.Failed(error.Message);
            }
        }
    }
