    public interface IClient
    {
        CurrentUser CurrentUser { get; set; }
    }
    public class LookUpClient : IClient
    {
        public CurrentUser CurrentUser {get;set;}
    }
    public class AffiliateClient : IClient
    {
        public CurrentUser CurrentUser { get; set; }
    }
    class Program
    {
        private static T GetClient<T>() where T : IClient, new()
        {
            T client = new T();
            client.CurrentUser = CurrentUser;
            return client;
        }
        static void Main(string[] args)
        {
            var lookup = GetClient<LookUpClient>();
            var affiliate = GetClient<AffiliateClient>();
        }
    }
