    public class ServiceRegistrationConvention : IRegistrationConvention
	{
		public void Process(Type type, Registry registry)
		{
			var interfacesImplemented = type.GetInterfaces();
			foreach (var interfaceImplemented in interfacesImplemented)
			{
				if (interfaceImplemented.IsGenericType && interfaceImplemented.GetGenericTypeDefinition() == typeof(IServiceOperation<,>))
				{
					var genericParameters = interfaceImplemented.GetGenericArguments();
					var closedValidatorType = typeof(ValidateServiceDecorator<,>).MakeGenericType(genericParameters);
					registry.For(interfaceImplemented)
						.EnrichWith((context, original) => Activator.CreateInstance(closedValidatorType, original,
						                                                            context.GetInstance<IValidationService>()));
				}
			}
		}
	}
