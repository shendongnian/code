    public class ContractModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
              if(modelType == typeof(Contract))
                {
                     if(LoggedIn)
                     {
                           return  new LoggedInContractBinder();
                     }
                     else
                     { 
                           return new NotLoggedContractBinder(); 
                     } 
                } 
               return null;
        }
    }
