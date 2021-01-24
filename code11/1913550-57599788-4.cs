    public static class MessageHandlerServiceCollectionExtensions
    {
        public static IServiceCollection AddMessageHandlers(this IServiceCollection services)
        {
            services.RegisterHandler<MessageOne, MessageOneHandler>();
            services.RegisterHandler<MessageTwo, MessageTwoHandler>();
            // some string constants for message types would be better.
            services.AddSingleton<IMessageHandlerFactory>(serviceProvider =>
            {
                var factory = new MessageHandlerFactory();
                factory.RegisterHandler("MessageOne",
                    serviceProvider.GetService<MessageHandlerWrapper<MessageOne>>);
                factory.RegisterHandler("MessageTwo",
                    serviceProvider.GetService<MessageHandlerWrapper<MessageTwo>>);
                return factory;
            });
            services.AddSingleton<IMessageHandler, MessageRouter>();
            return services;
        }
        static void RegisterHandler<TMessageType, THandler>(this IServiceCollection services)
            where TMessageType : class
            where THandler : IMessageHandler<TMessageType>
        {
            services.AddSingleton<TMessageType>();
            services.AddSingleton(
                serviceProvider => 
                    new MessageHandlerWrapper<TMessageType>(serviceProvider.GetService<THandler>())
            );
        }
    }
