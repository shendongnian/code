    PollingDuplexHttpBinding binding = new PollingDuplexHttpBinding(PollingDuplexHttpSecurityMode.None, PollingDuplexMode.MultipleMessagesPerPoll);
                binding.InactivityTimeout = new TimeSpan(2,0,0);
                binding.ReceiveTimeout = new TimeSpan(2, 0, 0);
    
              _client = new SLDuplexServiceClient(binding, new EndpointAddress("http://localhost/LpSystem.ServiceInterface.Web/SLDuplexService/SLDuplexService.svc"));
