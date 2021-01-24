    public static class MessageHandlerServiceCollectionExtensions
    {
        public static IServiceCollection AddMessageHandlers(this IServiceCollection services)
        {
            void RegisterHandler<TMessageType, THandler>() 
                where TMessageType : class
                where THandler : IMessageHandler<TMessageType>
            {
                services.AddSingleton<TMessageType>();
                services.AddSingleton(
                    serviceProvider => new MessageHandlerWrapper<TMessageType>(serviceProvider.GetService<THandler>())
                );
            }
            
            // MessageTypeOneHandler is the implementation of IMessageHandler<MessageTypeOne>
            RegisterHandler<MessageTypeOne, MessageTypeOneHandler>();
            RegisterHandler<MessageTypeTwo, MessageTypeTwoHandler>();
            // some string constants for message types would be better.
            services.AddSingleton<IMessageHandlerFactory>(serviceProvider =>
            {
                var factory = new MessageHandlerFactory();
                factory.RegisterHandler("messagetypeone",
                    serviceProvider.GetService<MessageHandlerWrapper<MessageTypeOne>>);
                factory.RegisterHandler("messagetypetwo",
                    serviceProvider.GetService<MessageHandlerWrapper<MessageTypeTwo>>);
                return factory;
            });
            services.AddSingleton<IMessageHandler, MessageRouter>();
            return services;
        }
    }
