    public interface IRemoteIpService
    {
        IPAddress GetRemoteIpAddress();
    }
    public class RemoteIpService : IRemoteIpService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RemoteIpService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IPAddress GetRemoteIpAddress()
        {
            return _httpContextAccessor.HttpContext.Connection.RemoteIpAddress;
        }
    }
    public class DummyRemoteIpService : IRemoteIpService
    {
        public IPAddress GetRemoteIpAddress()
        {
            //add your implementation
            return IPAddress.Parse("120.1.1.99");
        }
    }
