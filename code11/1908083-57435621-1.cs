    public class CustomAttributeOperationFilter : IOperationFilter
    {
        // variables
        MethodInfo _methodInfo;
        public void Apply(Operation operation, OperationFilterContext context)
        {
            context.ApiDescription.TryGetMethodInfo(out _methodInfo);
            var attributes = _methodInfo.GetCustomAttributes<CustomAttribute>();
            foreach (var atrib in attributes)
                operation.Extensions.Add(atrib.ParameterName, atrib.Value);
        }
    }
