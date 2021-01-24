    //for validating the server certificate. 
    ServicePointManager.ServerCertificateValidationCallback += delegate
                  {
                      return true;
                  };
                ServiceReference2.Service1Client client = new ServiceReference2.Service1Client();
                client.ClientCredentials.UserName.UserName = "jack";
                client.ClientCredentials.UserName.Password = "123456";
