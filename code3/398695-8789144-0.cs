        public IQueryable<Contract> GetSums()
        {
            var repository = new ContractsRepository(this.Context);
            return from c in repository.GetAll()
                   select new ContractSumsModel
                   {
                       Field1 = c.Field1,
                       Field2 = c.Field2,
                       Fields1and3 = Field1 + Field3,
                       Fields2and4 = Field2 + Field4
                   };
        }
