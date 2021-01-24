    abstract public class AbstractFactory
    {
        public abstract Client CreateClient();
        public abstract User CreateUser();
        public abstract Channel CreateChannel(BasicHttpBinding binding, EndpointAddress endpoint);
    }
public class AWIFactory : AbstractFactory
    {
        public override Channel CreateChannel(BasicHttpBinding binding, EndpointAddress endpoint)
        {
            var channelFactory = new ChannelFactory<WebServiceAWI>(binding, endpoint);
            return channelFactory.CreateChannel();
        }
        public override Client CreateClient()
        {
            return new WebServiceAWIClient();
        }
        public override User CreateUser()
        {
            return new ArmUser();
        }
    }
    public class WRGFactory : AbstractFactory
    {
        public override Channel CreateChannel(binding, endpoint)
        {
            var channelFactory = new ChannelFactory<WebServiceWRG>(binding, endpoint);
            return channelFactory.CreateChannel();
        }
        public override Client CreateClient()
        {
            return new WebServiceAWIClient();
        }
        public override User CreateUser()
        {
            return new User();
        }
    }
    public class WebService
    {
        private readonly AbstractFactory _factory;
        public WebService(AbstractFactory factory)
        {
            _factory = factory;
        }
        public async void ClaimSearchAsync(string url, string userName, string password, int statusCode)
        {
            var client = _factory.CreateClient();
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            var endpoint = new EndpointAddress(url);
            var channel = _factory.CreateChannel(binding, endpoint);
            var user = _factory.CreateUser();
            user.UserName = await channel.EncryptValueAsync(userName);
            user.Password = await channel.EncryptValueAsync(password);
            var response = await client.ClaimSearchAsync(user, "", "", 12345, statusCode, "");
        }
        ...
    }
  [1]: https://i.stack.imgur.com/xf7BP.png
