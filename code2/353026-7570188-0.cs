    public static class Transformers
    {
        public static void Register()
        {
            Mapper.CreateMap<Bank, EditBankViewModel>();
            Mapper.CreateMap<EditBankViewModel, Bank>();
            
            Mapper.CreateMap<Account, EditAccountViewModel>();
            Mapper.CreateMap<EditAccountViewModel, Account>();
  
            // And so on. You can break them up into private methods
            // if you have too many.
        }
    }
