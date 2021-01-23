    public interface ITransaction  {}
    public class MyTransaction1 : ITransaction, IDisposable { ... }
    public class MyTransaction2 : ITransaction { ... }
    public void EndTransaction(ITransaction transaction)
    {
       if (transaction != null)
       {
            (transaction as IDisposable).Dispose(); 
            // is the following code wrong? transaction.Dispose()
            transaction = null;
       }
    }
    /// This will succeed
    .EndTransaction (new MyTransaction1()); 
    /// This will throw an exception. There is not any check for null when performing the 'as'
    .EndTransaction (new MyTransaction2()); 
