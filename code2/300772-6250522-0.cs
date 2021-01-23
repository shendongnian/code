    class Account
    {
        public Account(IRepository<Account> repository)
        {
            _Repository = repository;
        }
        public void ChangeOwner(Owner newOwner)
        {
            // change ownership
            _Repository.Save(this);
        }
    }
