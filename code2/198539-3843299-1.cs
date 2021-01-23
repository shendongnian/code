    public partial class Type1LeaseTransactionVoid : ILeaseTransactionVoid
    {
        ILeaseTransactionVoid ILeaseTransaction.Void
        {
            get { return (ILeaseTransactionVoid)Void; }
        }
    }
