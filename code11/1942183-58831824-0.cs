    private static IBusControl ConfigureBus(IServiceProvider provider)
        {
            var options = provider.GetRequiredService<IOptions<AppConfig>>().Value;
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(options.Host, options.VirtualHost, h =>
                {
                    h.Username(options.Username);
                    h.Password(options.Password);
                });
                cfg.ReceiveEndpoint(host, "process-order", e =>
                {
                    e.Consumer(() => new ProcessOrderConsumer(provider.GetRequiredService<IConfiguration>()));
                    var a = new ProcessOrderRequestProxy(provider.GetRequiredService<IConfiguration>());
                    var b = new ResponseProxy();
                    e.Instance(a);
                    e.Instance(b);
                });
                var compensateCreateOrderAddress = new Uri(string.Concat("rabbitmq://localhost/", "compensate_createorder"));
                cfg.ReceiveEndpoint(host, "execute_createorder", e =>
                {
                    e.ExecuteActivityHost<CreateOrderActivity, CreateOrderArguments>(compensateCreateOrderAddress, () => new
                        CreateOrderActivity(provider.GetRequiredService<IOrderRepository>(), provider.GetRequiredService<IOrderDetailRepository>()));
                });
                cfg.ReceiveEndpoint(host, "compensate_createorder", e =>
                {
                    e.CompensateActivityHost<CreateOrderActivity, CreateOrderLog>(() => new
                        CreateOrderActivity(provider.GetRequiredService<IOrderRepository>(), provider.GetRequiredService<IOrderDetailRepository>()));
                });
            });
        }
 
