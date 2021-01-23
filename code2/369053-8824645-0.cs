    public IQueryable<Contract> AllContracts()
        {
            IQueryable<Contract> contracts =
                from c in DbDw().Contracts
                select c;
            return contracts;
        }
