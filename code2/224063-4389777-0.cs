    protected void ValidateExportDirectoryExists()     
    {
      using (GetNetworkAccess(username, password, domain))
      {                 
        CheckExportDirectoryExists();
      }
    } 
    
    protected IDisposable GetNetworkAccess(string username, string password, string domain)
    {
      return useNetworkAccess ? new Core.NetworkAccess(username, password, domain) : new NullNetworkAccess(username, password, domain);
    }
    internal class NullNetworkAccess : IDisposable
    {
      internal NullNetworkAccess(string username, string password, string domain)
      {
      }
      public void Dispose()
      {
      }
    }
  
