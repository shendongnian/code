    interface IOperationAttribute
    {
    }
    [Development]
    public class OperationDevelopment : IOperation
    {
        public Guid OperationId { get; }
    }
    public class DevelopmentAttribute : Attribute, IOperationAttribute
    {
    }
	public static IServiceCollection AddOperationServices(this IServiceCollection services)
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
