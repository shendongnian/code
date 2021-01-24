	public static class AppServiceExtension
    {    
		public static IServiceCollection AppOperationServices(this IServiceCollection services)
		{
			var typesWithOperationAttribute =
				from a in AppDomain.CurrentDomain.GetAssemblies()
				from t in a.GetTypes()
				let attributes = t.GetCustomAttributes(typeof(IOperationAttribute), true)
				where attributes != null && attributes.Length > 0
				select new { Type = t };
			
			foreach (var item in typesWithOperationAttribute)
				services.AddTransient((Type)item.Type);
			return services;
		}
	}
	
