    public abstract class AzureTableBase<T> : IAzureTable<T> where T : BaseTable
    {
         // don't need to re-generalize this function, T is already inherited from your class
         public virtual T Get(string pkey, string rkey)
         {
             var a = this.Query.Where(u => u.PartitionKey == pkey && u.RowKey == rkey);
             return a.FirstOrDefault();     // again, only guessing.
         }
    
         public virtual IQueryable<T> Query
         {
            get
            {
                TableServiceContext context = CreateContext();
                return context.CreateQuery<T>(TableName).AsTableServiceQuery();
            }
         }
    }
