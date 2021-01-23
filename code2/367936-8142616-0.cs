	public class ServiceRegistrationConvention : IRegistrationConvention
	{
		public void Process(Type type, Registry registry)
		{
			var handlerInterfaces = (from t in type.GetInterfaces()
			                         where t.IsGenericType &&
			                               t.GetGenericTypeDefinition() == typeof (IHandle<,>)
			                         select t);
			foreach (var handler in handlerInterfaces)
			{
				var decoratorType = typeof (ValidationDecorator<,>).MakeGenericType(handler.GetGenericArguments());
				registry.For(handler)
					.EnrichWith((ctx, orig) => ObjectFactory.With(handler, orig).GetInstance(decoratorType));
			}
		}
	}
