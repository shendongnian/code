    public class InvoicerService : DataService<DtcInvoicerDbEntities>
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("Employees", EntitySetRights.AllRead);
            config.SetEntitySetPageSize("*", 25);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
        }
    }
