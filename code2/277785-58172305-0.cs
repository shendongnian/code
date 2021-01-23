cs
    using Microsoft.Extensions.ObjectPool;  
    using Microsoft.Extensions.Options;  
    using RabbitMQ.Client;  
      
    public class RabbitModelPooledObjectPolicy : IPooledObjectPolicy<IModel>  
    {  
        private readonly RabbitOptions _options;  
      
        private readonly IConnection _connection;  
      
        public RabbitModelPooledObjectPolicy(IOptions<RabbitOptions> optionsAccs)  
        {  
            _options = optionsAccs.Value;  
            _connection = GetConnection();  
        }  
      
        private IConnection GetConnection()  
        {  
            var factory = new ConnectionFactory()  
            {  
                HostName = _options.HostName,  
                UserName = _options.UserName,  
                Password = _options.Password,  
                Port = _options.Port,  
                VirtualHost = _options.VHost,  
            };  
      
            return factory.CreateConnection();  
        }  
      
        public IModel Create()  
        {  
            return _connection.CreateModel();  
        }  
      
        public bool Return(IModel obj)  
        {  
            if (obj.IsOpen)  
            {  
                return true;  
            }  
            else  
            {  
                obj?.Dispose();  
                return false;  
            }  
        }  
    }  
Then configure dependency injection for ObjectPool
cs
services.AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();
services.AddSingleton(s =>
{
   var provider = s.GetRequiredService<ObjectPoolProvider>();
   return provider.Create(new RabbitModelPooledObjectPolicy());
});
You can then inject `ObjectPool<IModel>`, and use it
cs
var channel = pool.Get();
try
{
    channel.BasicPublish(...);
}
finally
{
    pool.Return(channel);
}
Sources:
https://www.c-sharpcorner.com/article/publishing-rabbitmq-message-in-asp-net-core/
https://developpaper.com/detailed-explanation-of-object-pools-various-usages-in-net-core/
