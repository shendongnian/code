    public Task<decimal> SearchPDFAsync(string searchTerm, CancellationToken cancellationToken)
    {
       try
       {
    
          return Task.Run(() => {
             ...
          });
    
       }
       catch (Exception ex)
       {
          return Task.FromException<decimal>(ex);
       }
    }
