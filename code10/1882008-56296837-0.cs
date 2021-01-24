    string serverName = "myserver.database.windows.net"; 
    string databaseName = "test";
    string clientId = "xxxxxx-xxxxx-xxxxx-xxxx-xxxx"; 
    string aadTenantId = "xxxxxx-xxxxxx-xxxxxx-xxxxxx-xxxxxxxx";
    string clientSecretKey = "xxxxx/xxxxxx/xxxxx";
    string sqlConnectionString = String.Format("Data Source=tcp:{0},1433;Initial Catalog={1};Persist Security Info=False;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False", serverName, databaseName);
    string AadInstance = "https://login.windows.net/{0}";
    string ResourceId = "https://database.windows.net/";
    AuthenticationContext authenticationContext = new AuthenticationContext(string.Format(AadInstance, aadTenantId));
    ClientCredential clientCredential = new ClientCredential(clientId, clientSecretKey);
    DateTime startTime = DateTime.Now;
    Console.WriteLine("Time " + String.Format("{0:mm:ss.fff}", startTime));
    AuthenticationResult authenticationResult = authenticationContext.AcquireTokenAsync(ResourceId, clientCredential).Result;
    DateTime endTime = DateTime.Now;
    Console.WriteLine("Got token at " + String.Format("{0:mm:ss.fff}", endTime));
    Console.WriteLine("Total time to get token in milliseconds " + (endTime - startTime).TotalMilliseconds);
    using (var conn = new SqlConnection(sqlConnectionString))
    {
         conn.AccessToken = authenticationResult.AccessToken;
         //DO STUFF
    }
