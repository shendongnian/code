    class BusinessRulesFactory<TService> where TService : IBusinessRules
    {
         public TService GetObject(int clientIdentityCode)
         {
             // ... choose business rule in respect to both clientIdentityCode and TService
         }
    }
