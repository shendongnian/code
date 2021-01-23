    private static ExchangeService getService(String userEmail, String login, String password, String hostName)
        {
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010); 
            AutodiscoverService auservice = new AutodiscoverService(hostName);
            if (auservice.ServerInfo != null) 
            {
                try
                {
                    service.AutodiscoverUrl(userEmail, RedirectionUrlValidationCallback);
                }
                catch (AutodiscoverRemoteException ex)
                {
                    Console.WriteLine("Exception thrown: " + ex.Error.Message);
                }
            }
            else
            {
                service.Url = new Uri("https://" + hostName + "/EWS/Exchange.asmx");
            }
            service.UseDefaultCredentials = true;
            if (service.ServerInfo == null)
            {
                service.Credentials = new WebCredentials(login, password);
            }
            return service;
        }
