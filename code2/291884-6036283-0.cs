    public partial class Client
    {
        public void GenerateInvoice()
        {
            // ... etc ...
        }
    }
    
    List<Client> clientList = MyDatabaseContext.Clients.ToList();
    
    clientList[ someIndex ].SomeField = NewValue;
    MyDatabaseContext.SubmitChanges();
