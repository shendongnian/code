builder.Register(context =>
                {
                    var bus = Bus.Factory.CreateUsingRabbitMq(opt =>
                    {
                        var result = new List<string>();
                        Configuration.GetSection("RabbitMq:HostNames").Bind(result);
                        var host = opt.Host(result[0], Configuration.GetValue<string>("RabbitMq:VirtualHost"), h =>
                        {
                            h.Username(Configuration.GetValue<string>("RabbitMq:Username"));
                            h.Password(Configuration.GetValue<string>("RabbitMq:Password"));
                        });
                        ContainerBuilder b = new ContainerBuilder();
                        b.Register<IRabbitMqHost>(a => host).SingleInstance();
                        b.Update(ApplicationContainer);
                    });
                    return bus;
                }).As<IBus>()
                .As<IBusControl>()
                .SingleInstance();
``
