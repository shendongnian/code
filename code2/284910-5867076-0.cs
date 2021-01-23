    public interface ITransaction : IDisposable
    {
    }
    public interface ITransactionFactory 
    {
        ITransaction CreateTransaction();
    }
    public class Foo
    {
        private readonly ITransactionFactory transactionFactory;
        public Foo(ITransactionFactory transactionFactory)
        {
            this.transactionFactory = transactionFactory;            
        }
        public void DoSomethingWithinTransaction()
        {
            using(ITransaction transaction = this.transactionFactory.CreateTransaction())
            {
                DoSomething();
            }
        }
    }
