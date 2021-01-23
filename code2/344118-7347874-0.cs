    interface IDbContract
    {
       string TableName { get; }
    }
    
    public sealed class DbContractFactory
    {
       private readonly IDictionary<Type, IDbContract> dbContractMap;
    
       public void RegisterContract<TEntity>(IDbContract)
       {
             // store in dbContractMap
       }
        
       public IDbContract GetDbContract<TEntity>()
       {  
           if (dbContractMap.Contains(typeof(TEntity))
           {
              // retrieve and return
           }    
       }
    }
