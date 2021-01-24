    services.AddSingleton<IServiceBusClient, ServiceBusClient>((p) =>
                    {
                        var diagnostics = p.GetService<EventHandling>();
                        var sbc = new ServiceBusClient(
                            programOptions.Endpoint,
                            programOptions.TopicName,
                            programOptions.Subscriber,
                            programOptions.SubscriberKey);
                        sbc.Exception += exception => diagnostics.HandleException(exception);
                        return sbc;
                    });
