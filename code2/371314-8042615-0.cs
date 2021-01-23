    void GetDataAsync(
      string parameters, 
      Action<IEnumerable<object>> onSuccess, 
      Action<Exception> onError) {
    
      WaitCallback doWork = delegate { 
        try { 
          IEnumerable<object> enumerable = GetTheData(parameters);
          onSuccess(enumerable);
        } catch (Exception ex) {
          onError(ex);
        }
      };
    
      ThreadPool.QueueUserWorkItem(doWork, null);
    }
