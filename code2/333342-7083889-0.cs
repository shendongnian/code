    public interface IDbEntity 
    {
    }
    
    public interface IDbContract
    {
          string SelectByIdQuery { get; }
    }
    
    public sealed class DataBaseContractFactory
    {
        public IDbContract CreateContract<TEntity>()
          where TEntity: IDbEntity
        {
           if (typeof(TEntity) == typeof(ICustomer))
           {
               return this.customerDbContract;
           }
        }
    }
    
    public sealed class SqlMethods
    {
       public SqlMethods(DataBaseContractFactory dbContractFactory)
       {
            // assign to private field
       }
    
       public T SelectEntity<TEntity>(int entityId)
          where TEntity: IDbEntity
       {
           IDbContract contract = this.dbContractFactory.CreateContract<TEntity>();
           string sqlQuery = String.Format(contract.SelectByIdQuery, id);
    
           IDataReader dataReader = ExecuteStatement(sqlQuery);
           return this.BuildEntytyFromDataReader<TEntity>(dataReader);
       }
    }
