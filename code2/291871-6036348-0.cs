    public class UrlManagementClientProxy : IUrlManagementProxy 
    {
         // we need a reference to the underlying client
         private readonly UrlManagementServiceClient _client;
       
         // underlying client is passed to the proxy in constructor
         public UrlManagementClientProxy(UrlManagementServiceClient client)
         {
             _client = client;
         }
         #region IUrlManagementProxy methods
         // you implementation goes here. if the underlying client
         // already implements a certain method, then you just need
         // to pass the call 
         // for example, client already implements methods
         // from the IUrlManagementService interface, so use them
         public string GetUrl() // made up
         {
              return _client.GetUrl();
         }
 
         #endregion
    }
