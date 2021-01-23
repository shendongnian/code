    public class ServiceA : IServiceA
    {
        public async Task<string> GetGreeting(string name)
        {
            ServiceBClient client = new ServiceBClient();
            return await client.GetGreetingAsync();
        }
    }
