        public static class UnitOfWorkExtension`
        {
            public static IPersonRepository GetPersonRepository( this UnitOfWork uow)
            {
                 return new PersonRepository(uow);
            }
    
            public static IAccountRepository GetAccountRepository( this UnitofWork uow )
            {
                 return new AccountRepository(uow);
            }
        }
