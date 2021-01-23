    public class MyBusinessTransactionFactory
    {
        public IBusinessTransaction Create(Type t)
        {
            return new MyBusinessTransaction();
        }
    }
