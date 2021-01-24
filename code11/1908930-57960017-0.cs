c#
c.AddSecurityDefinition("Bearer", new ApiKeyScheme
{
    In = "header",
    Description = "Please enter into field the word 'Bearer' following by space and your JWT token",
    Name = "Authorization",
    Type = "apiKey"
});
c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
{
    { "Bearer", Enumerable.Empty<string>() },
});
And I added the following one:  
c#
c.OperationFilter<AddAuthHeaderOperationFilter>();
And of course the `AddAuthHeaderOperationFilter.cs`:  
c#
    public class AddAuthHeaderOperationFilter : IOperationFilter
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public AddAuthHeaderOperationFilter(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var filterDescriptor = context.ApiDescription.ActionDescriptor.FilterDescriptors;
            var isAuthorized = filterDescriptor.Select(filterInfo => filterInfo.Filter).Any(filter => filter is AuthorizeFilter);
            var allowAnonymous = filterDescriptor.Select(filterInfo => filterInfo.Filter).Any(filter => filter is IAllowAnonymousFilter);
            if (isAuthorized && !allowAnonymous)
            {
                if (operation.Parameters == null)
                    operation.Parameters = new List<IParameter>();
                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "Authorization",
                    In = "header",
                    Description = "JWT access token",
                    Required = true,
                    Type = "string",
                    //Default = $"Bearer {token}"
                });
                operation.Responses.Add("401", new Response { Description = "Unauthorized" });
                operation.Responses.Add("403", new Response { Description = "Forbidden" });
                operation.Security = new List<IDictionary<string, IEnumerable<string>>>();
                //Add JWT bearer type
                operation.Security.Add(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] { } }
                });
            }
        }
    }
Shortly, this OperationFilter class only adds the locker icon to methods that require Authorization. The locker is always Opened though. So not the perfect solution, but for now is ok.
Here is how it looks:
[![enter image description here][1]][1]
Note: So if you want to test the API, you first get a token and then fill it where needed.
  [1]: https://i.stack.imgur.com/wqHGX.png
