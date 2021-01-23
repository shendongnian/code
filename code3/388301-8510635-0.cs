    public class MyTransaction
    {
        System.Data.DBTransaction myTx = someConnection.CreateTransaction();
    
        public void CommitTransaction() :  {
            myTx.CommitTransaction()
        }
    }
