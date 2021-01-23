    public class SomeClass<T> where T : IDBInteractor <T>
    {
        private IDBInteractor<T> _interactor;
        public SomeClass(IDBInteractor<T> interactor)
        {
            _interactor = interactor;
        }
        public T ExecuteQuery(string myQuery)
        {
           return _interactor.ExecuteDSQuery(myQuery);
        }
    }
