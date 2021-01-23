    public interface ILookupDataProvider<T>
        {
            void GetDataAsync(string parameters, Action<IEnumerable<T>> onSuccess, Action<Exception> onError);
        }
    
        public class LookupDataProvider<T> : ILookupDataProvider<T>
