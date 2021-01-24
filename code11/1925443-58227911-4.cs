    public interface IFactory
    {
        Client CreateClient();
        User CreateUser();
        Channel CreateChannel(BasicHttpBinding binding, EndpointAddress endpoint);
    }
    abstract public class AbstractFactory<T> : IFactory
    {
        public abstract Client CreateClient()
        public abstract User CreateUser();
        public Channel CreateChannel(BasicHttpBinding binding, EndpointAddress endpoint)
        {
            var channelFactory = new ChannelFactory<T>(binding, endpoint);
            return channelFactory.CreateChannel();
        }
    }
    public class AWIFactory : AbstractFactory<WebServiceAWI>
    {
        public override Client CreateClient()
        {
            return new WebServiceAWIClient();
        }
        public override User CreateUser()
        {
            return new ArmUser();
        }
    }
    public class WRGFactory : AbstractFactory<WebServiceWRG>
    {
        public override Client CreateClient()
        {
            return new WebServiceWRGClient();
        }
        public override User CreateUser()
        {
            return new User();
        }
    }
    public class WebService
    {
        private readonly IFactory _factory;
        public WebService(IFactory factory)
        {
            _factory = factory;
        }
        public async void ClaimSearchAsync(string url, string userName, string password)
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
