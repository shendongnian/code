            static void Main(string[] args)
            {
                //instantiate the class ServiceTokenClient wish provide the getToken method with endpoint configuration name and remote adress. 
    			//look at web.config or app.config to get the name of endpoint configuration <binding name="BasicHttpBinding_IServiceToken" />
                //https://myservices.fr/Connectors/TokenConnector/ServiceToken.svc	is the URL of our web services provided by the host.
    			
                ServiceTokenClient _srvToken = new ServiceTokenClient("BasicHttpBinding_IServiceToken", "https://myservices.fr/Connectors/TokenConnector/ServiceToken.svc");
    
    			//Set a certificate
    			// Use the X509Store class to get a handle to the local certificate stores. "My" is the "Personal" store. Don't forget using System.Security.Cryptography and System.Security.Cryptography.X509Certificates;
                _srvToken.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.My, X509FindType.FindBySerialNumber, "XXXXXXXXXXXXXXXXXXXXXXXXXXX");
                ((BasicHttpBinding)_srvToken.Endpoint.Binding).Security.Mode = BasicHttpSecurityMode.Transport; //set the security mode
                ((BasicHttpBinding)_srvToken.Endpoint.Binding).Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate; //set the type of client credential.
    
                //Making Call
                var _objToken = _srvToken.getToken("myLogin", "mypassword", "myEmail");
                Console.WriteLine("{0}", _objToken.Token);  // Display the token
                Console.ReadKey();
    
            }
    
