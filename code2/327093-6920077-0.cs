    public class TransactionRepository : IRepository<Transaction>
    {
       public TTransaction Find<TTransaction>(int transactionId) 
          where TTransaction  : TransactionBase, new()
       {
          return _ctx.Transactions.OfType<TTransaction>().SingleOrDefault(tran => tran.TransactionId == transactionId);
       }
    }
