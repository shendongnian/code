        public static void AddConsumersFromContainer(this IRegistrationConfigurator configurator, IComponentContext context)
        {
            var consumerTypes = context.FindTypes(IsConsumerOrDefinition);
            configurator.AddConsumers(consumerTypes);
        }
        public static void AddSagasFromContainer(this IRegistrationConfigurator configurator, IComponentContext context)
        {
            var sagaTypes = context.FindTypes(IsSagaOrDefinition);
            configurator.AddSagas(sagaTypes);
        }
        static Type[] FindTypes(this IComponentContext context, Func<Type, bool> filter)
        {
            return context.ComponentRegistry.Registrations
                .SelectMany(r => r.Services.OfType<IServiceWithType>(), (r, s) => (r, s))
                .Where(rs => filter(rs.s.ServiceType))
                .Select(rs => rs.s.ServiceType)
                .ToArray();
        }
        /// <summary>
        /// Returns true if the type is a consumer, or a consumer definition
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsConsumerOrDefinition(Type type)
        {
            Type[] interfaces = type.GetTypeInfo().GetInterfaces();
            return interfaces.Any(t => t.HasInterface(typeof(IConsumer<>)) || t.HasInterface(typeof(IConsumerDefinition<>)));
        }
        /// <summary>
        /// Returns true if the type is a saga, or a saga definition
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsSagaOrDefinition(Type type)
        {
            Type[] interfaces = type.GetTypeInfo().GetInterfaces();
            if (interfaces.Contains(typeof(ISaga)))
                return true;
            return interfaces.Any(t => t.HasInterface(typeof(InitiatedBy<>))
                || t.HasInterface(typeof(Orchestrates<>))
                || t.HasInterface(typeof(Observes<,>))
                || t.HasInterface(typeof(ISagaDefinition<>)));
        }
