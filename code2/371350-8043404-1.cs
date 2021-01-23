    public class LookupDataProvider<T> : ILookupDataProvider 
    {
      public void GetDataAsync(
        string parameters,
        Action<IEnumerable<object>> onSuccess,
        Action<Exception> onError)
      {
        Action<IEnumerable<T>> onSuccessGeneric = x => onSuccess(x.OfType<object>());
        this.GetDataAsync(parameters, onSuccess, onError);
      }
    
      public void GetDataAsync(
        string parameters,
        Action<IEnumerable<T>> onSuccess,
        Action<Exception> onError) 
      { 
        // as you had it before.
      } 
    }
