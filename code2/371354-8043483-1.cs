    public class LookupDataProvider : ILookupDataProvider
    {
    
        public void GetDataAsync<T>(string parameters, Action<IEnumerable<T>> onSuccess, Action<Exception> onError)
        {
    
        }
    
        void ILookupDataProvider.GetDataAsync(string parameters, Action<IEnumerable<object>> onSuccess, Action<Exception> onError)        
        {
             this.GetDataAsync<Object>(parameters, onSuccess, onError);
        }
    
    }
