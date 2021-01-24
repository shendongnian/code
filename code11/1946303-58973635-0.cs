    internal class AssignContentTypeFilter : IOperationFilter
    {
    
    	public void Apply(Operation operation, OperationFilterContext context)
    	{
    		operation.Consumes.Clear();
    		operation.Consumes.Add("application/json");
    
    		operation.Produces.Clear();
    		operation.Produces.Add("application/json");
    	}
    }
