    public class MockDataService : IDataService
    {
        private SomeServiceChannel _channel;
    
        public MockDataService()
        {
            var channelFactory = new ChannelFactory<SomeServiceChannel>(
                        "CustomBinding_SomeService");
            _channel = channelFactory.CreateChannel();
            //to increase the timeout
            _channel.OperationTimeout = TimeSpan.FromMinutes(5);
        }
    
        public void GetUserId(string userName, string password, Action<int> getUserIdComplete)
        {
            var request = new UserRequest();
            request.UserName = userName;
            request.Password = password;
            //populate any other request info
    
            _proxy.GetUserIdCompleted += new EventHandler<GetUserCompletedEventArgs>(_proxy_GetUserIdCompleted);
            _proxy.GetUserIdAsync(request);
            _channel.BeginGetUserId(request, (iar) =>
               {
                   try
                   {
                       var result = _channel.EndGetUserId(iar);
                       getUserIdComplete(result.UserId);
                   }
                   catch (Exception ex)
                   {
                       //handle the exception
                   }
               }, null);
        }
    
    }
    
