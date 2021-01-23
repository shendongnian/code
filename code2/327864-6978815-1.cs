          public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetServiceOperationAccessRule("DbUsers", ServiceOperationRights.AllRead);
        }
        [WebGet]
        public IQueryable<User> DbUsers()
        {
            return CurrentDataSource.DbPersons.OfType<User>();
        }
