    public class ManualDependencyResolver : IDependencyResolver
    {
        public T Resolve<T>()
        {
            if (typeof(T)==typeof(ITransactionRepository))
            {
                return new CheckTransactionRespostory(new DataContext());
            }
            
            throw new Exception("No dependencies were found for the given type.");
        }
    }
