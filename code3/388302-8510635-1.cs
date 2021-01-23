    public class MyTransaction
    {
        System.Data.SqlTransaction myTx = someConnection.CreateTransaction();
    
        public void CommitTransaction() :  {
            myTx.CommitTransaction()
        }
    }
