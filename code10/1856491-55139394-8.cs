    class OrdersRepository
    {
        public IReadOnlyRepository CreateReadOnly()
        {
             // TODO: if desired check rights: can this user access this database?
             return new Repository();
        }
        public IRepository CreateUpdateAccess()
        {
             // TODO: if desired check rights: can this user access this database?
             return new Repository();
        }
        public Repository CreateFullControl()
        {
             // TODO: if desired check rights: can this user access this database?
             return new Repository();
        }
