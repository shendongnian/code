    public partial class [TableAdapterName]
    {
        public void EnlistTransaction(System.Data.SqlClient.SqlTransaction transaction)
        {
            System.Data.SqlClient.SqlTransaction _transaction;
            
            if (this._transaction != null)
            {
                throw new System.InvalidOperationException
    		("This adapter has already been enlisted in a transaction");
            }
            else
            {
                this._transaction = transaction;
                Adapter.UpdateCommand.Transaction = _transaction;
                Adapter.InsertCommand.Transaction = _transaction;
                Adapter.DeleteCommand.Transaction = _transaction;
            }
        }
    }
