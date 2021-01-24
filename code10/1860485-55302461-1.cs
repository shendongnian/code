    public async Task<string> GetStringFromAPIWithRetryAsync(string resource, int maxRetry)
    {
        // limit retry to 1 .. 100
        for( int retry = Math.Min(Math.Max(1,maxRetry),100); retry > 0 ; retry--){
           try{
              return await GetStringFromAPIAsync( resource );
           }
           catch(Exception ex){ // Actually, you'd only catch exceptions where a retry makes sense.
              if( retry > 0 ){
                 Log.Warn("Attempt to get string from {0} failed! Reason: {1}", resource, ex.Message);
              }else{
                 throw;
              }
           }
        }
    }
