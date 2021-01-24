csharp
public class CustomTokenFilterAttribute : RequestFilterAsyncAttribute
{
    public List<string> RequireRoles { get; } 
    public CustomTokenFilterAttribute(params string[] roles)
    {
        RequireRoles = roles?.ToList();
    }
}
