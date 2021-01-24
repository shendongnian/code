[AttributeUsage(AttributeTargets.Property, AllowMultiple=false)]
internal class RequireRolesForBindingAttribute : Attribute
{
    public string[] Roles {get;}
    public RequireRolesForBindingAttribute(params string[] roles)
    {
        this.Roles = roles;
    }
}
Now when some roles are required, simply annotate the target property like below:
public class MySubmit
{
    public string Name { get; set; }
    public string IsActive { get; set; }
    // only an root/admin can bind this field for all other users, this should be empty
    [RequireRolesForBindingAttribute("root","admin")]
    public string Comment { get; set; }
    public Sub Sub{get;set;}    // test it with a complex child 
}
public class Sub{
    public int Id {get;set;}
    public string Name {get;set;}
    [RequireRolesForBindingAttribute("root","admin")]
    public string Note {get;set;}
}
The above data annotation represents that the two properties should be erased if the user has no rights:
- `Comment` property of `MySubmit`
- `Note` property of `Sub`
Finally, don't forget to enable an custom action filter. For example, add it on action method:
[TypeFilter(typeof(RequireRolesForBindingFilter))]
public IActionResult Test(MySubmit mySubmit)
{
    return Ok(mySubmit);
}
### An Implementation of `RequireRolesForBindingFilter`
I create an implementation of `RequireRolesForBindingFilter` for your reference:
csharp
public class RequireRolesForBindingFilter : IAsyncActionFilter
{
    private readonly IAuthorizationService _authSvc;
    public RequireRolesForBindingFilter(IAuthorizationService authSvc)
    {
        this._authSvc = authSvc;
    }
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // skip early when User ==null, 
        //    if you don't want to allow anonymous access, use `[Authorize]`
        if(context.HttpContext.User !=null) {  
            await this._checkUserRights(context.ActionArguments, context.HttpContext.User);
        }
        await next();
    }
    private async Task _checkUserRights(IDictionary<string, object> args, ClaimsPrincipal user){
        // handle each argument
        foreach(var kvp in args){
            if(kvp.Value==null) { return; }
            var valueType = kvp.Value.GetType();
            if(await _shouldSetNullForType(valueType, user)) {
                args[kvp.Key] = valueType.IsValueType? Activator.CreateInstance(valueType) : null;
            }else{
                // handle each property of this argument
                foreach(var pi in valueType.GetProperties())
                {
                    var pv = pi.GetValue(kvp.Value);
                    await _checkPropertiesRecursive( instanceValue: kvp.Value, propInfo: pi, user: user);
                }
            }
        }
        async Task<bool> _shouldSetNullForType(Type type, ClaimsPrincipal user)
        {
            // the `RequireRolesForBindingAttribute`
            var attr= type 
                .GetCustomAttributes(typeof(RequireRolesForBindingAttribute), false)
                .OfType<RequireRolesForBindingAttribute>()
                .FirstOrDefault();
            return await _shouldSetNullForAttribute(attr,user);
        }
        async Task<bool> _shouldSetNullForPropInfo(PropertyInfo pi, ClaimsPrincipal user)
        {
            // the `RequireRolesForBindingAttribute`
            var attr= pi
                .GetCustomAttributes(typeof(RequireRolesForBindingAttribute), false)
                .OfType<RequireRolesForBindingAttribute>()
                .FirstOrDefault();
            return await _shouldSetNullForAttribute(attr,user);
        }
        async Task<bool> _shouldSetNullForAttribute(RequireRolesForBindingAttribute attr, ClaimsPrincipal user)
        {
            if(attr!=null) {
                var policy = new AuthorizationPolicyBuilder().RequireRole(attr.Roles).Build();
                // does the user have the rights?
                var authResult = await this._authSvc.AuthorizeAsync(user, null, policy);
                if(!authResult.Succeeded){ 
                    return true;
                }
            }
            return false;
        }
        // check one property (propInfo) for instance `instanceValue`
        async Task _checkPropertiesRecursive(object instanceValue, PropertyInfo propInfo,  ClaimsPrincipal user){
            if(instanceValue == null) return;
            Type propType = propInfo.PropertyType;
            object propValue = propInfo.GetValue(instanceValue);
            if(await _shouldSetNullForPropInfo(propInfo, user))
            {
                propInfo.SetValue(instanceValue, propType.IsValueType? Activator.CreateInstance(propType) : null);
            }
            else if( !shouldSkipCheckChildren(propType) && propValue!=null ){ 
                // process every sub property for this propType
                foreach(var spi in propType.GetProperties()) 
                {
                    await _checkPropertiesRecursive(instanceValue: propValue , spi, user );
                }
            }
            bool shouldSkipCheckChildren(Type type) => (type == typeof(string) || type == typeof(DateTime));
        }
    }
}
### Demo:
When some user, who has no rights to submit the comment and note filed, sends a payload as below:
POST https://localhost:5001/home/test
cookie: <my-cookie>
Content-Type: application/x-www-form-urlencoded
name=a&isActive=true&comment=abc&sub.Name=s1&sub.note=magic
The response will be:
HTTP/1.1 200 OK
Connection: close
Content-Type: application/json; charset=utf-8
Server: Kestrel
Transfer-Encoding: chunked
{
  "name": "a",
  "isActive": "true",
  "comment": null,
  "sub": {
    "id": 0,
    "name": "s1",
    "note": null
  }
}
