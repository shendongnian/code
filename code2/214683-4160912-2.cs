    public sealed class Customer
    {
        //can only be created by a db service layer
        internal Customer(IDbContext databaseContext)
        {
        }
        [EntityMapping("Name")]
        public string Name
        {
            get
            {
                return context.HydrateValue(this, "Name");
            }
            set
            {
                InternalNotifyRevision("Name", value);
            }
        }
    }
