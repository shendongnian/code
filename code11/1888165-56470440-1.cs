public class ResourcesController : ApiController
{
  [EnableCors("http://localhost:55912", // Origin
              null,                     // Request headers
              "GET",                    // HTTP methods
              "bar",                    // Response headers
              SupportsCredentials=true  // Allow credentials
  )]
  public HttpResponseMessage Get(int id)
  {
    var resp = Request.CreateResponse(HttpStatusCode.NoContent);
    resp.Headers.Add("bar", "a bar value");
    return resp;
  }
  [EnableCors("http://localhost:55912",       // Origin
              "Accept, Origin, Content-Type", // Request headers
              "PUT",                          // HTTP methods
              PreflightMaxAge=600             // Preflight cache duration
  )]
  public HttpResponseMessage Put(Resource data)
  {
    return Request.CreateResponse(HttpStatusCode.OK, data);
  }
  [EnableCors("http://localhost:55912",       // Origin
              "Accept, Origin, Content-Type", // Request headers
              "POST",                         // HTTP methods
              PreflightMaxAge=600             // Preflight cache duration
  )]
  public HttpResponseMessage Post(Resource data)
  {
    return Request.CreateResponse(HttpStatusCode.OK, data);
  }
}
Notice each of the constructor parameters is a string. Multiple values are indicated by specifying a comma-separated list (as is specified for the allowed request headers in **Figure 2**). If you wish to allow all origins, request headers or HTTP methods, you can use a “*” as the value (you must still be explicit for response headers).
In addition to applying the EnableCors attribute at the method level, you can also apply it at the class level or globally to the application. The level at which the attribute is applied configures CORS for all requests at that level and below in your Web API code. So, for example, if applied at the method level, the policy will only apply to requests for that action, whereas if applied at the class level, the policy will be for all requests to that controller. Finally, if applied globally, the policy will be for all requests.
Following is another example of applying the attribute at the class level. The settings used in this example are quite permissive because the wildcard is used for the allowed origins, request headers and HTTP methods:
[EnableCors("*", "*", "*")]
public class ResourcesController : ApiController
{
  public HttpResponseMessage Put(Resource data)
  {
    return Request.CreateResponse(HttpStatusCode.OK, data);
  }
  public HttpResponseMessage Post(Resource data)
  {
    return Request.CreateResponse(HttpStatusCode.OK, data);
  }
}
If there’s a policy at multiple locations, the “closest” attribute is used and the others are ignored (so the precedence is method, then class, then global). If you’ve applied the policy at a higher level but then wish to exclude a request at a lower level, you can use another attribute class called DisableCorsAttribute. This attribute, in essence, is a policy with no permissions allowed.
If you have other methods on the controller where you don’t want to allow CORS, you can use one of two options. First, you can be explicit in the HTTP method list, as shown in **Figure 3**. Or you can leave the wildcard, but exclude the Delete method with the DisableCors attribute, as shown in **Figure 4**.
## Figure 3 Using Explicit Values for HTTP Methods
[EnableCors("*", "*", "PUT, POST")]
public class ResourcesController : ApiController
{
  public HttpResponseMessage Put(Resource data)
  {
    return Request.CreateResponse(HttpStatusCode.OK, data);
  }
  public HttpResponseMessage Post(Resource data)
  {
    return Request.CreateResponse(HttpStatusCode.OK, data);
  }
  // CORS not allowed because DELETE is not in the method list above
  public HttpResponseMessage Delete(int id)
  {
    return Request.CreateResponse(HttpStatusCode.NoContent);
  }
}
## Figure 4 Using the DisableCors Attribute
[EnableCors("*", "*", "*")]
public class ResourcesController : ApiController
{
  public HttpResponseMessage Put(Resource data)
  {
    return Request.CreateResponse(HttpStatusCode.OK, data);
  }
  public HttpResponseMessage Post(Resource data)
  {
    return Request.CreateResponse(HttpStatusCode.OK, data);
  }
  // CORS not allowed because of the [DisableCors] attribute
  [DisableCors]
  public HttpResponseMessage Delete(int id)
  {
    return Request.CreateResponse(HttpStatusCode.NoContent);
  }
}
**CorsMessageHandler** The CorsMessageHandler must be enabled for the CORS framework to perform its job of intercepting requests to evaluate the CORS policy and emit the CORS response headers. Enabling the message handler is typically done in the application’s Web API configuration class by invoking the EnableCors extension method:
public static class WebApiConfig
{
  public static void Register(HttpConfiguration config)
  {
    // Other configuration omitted
    config.EnableCors();
  }
}
If you wish to provide a global CORS policy, you can pass an instance of the EnableCorsAttribute class as a parameter to the EnableCors method. For example, the following code would configure a permissive CORS policy globally within the application:
public static class WebApiConfig
{
  public static void Register(HttpConfiguration config)
  {
    // Other configuration omitted
    config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
  }
}
As with any message handler, the CorsMessageHandler can alternatively be registered per-route rather than globally.
So that’s it for the basic, “out of the box” CORS framework in ASP.NET Web API 2. One nice thing about the framework is that it’s extensible for more dynamic scenarios, which I’ll look at next.
# Customizing Policy
It should be obvious from the earlier examples that the list of origins (if the wildcard isn’t being used) is a static list compiled into the Web API code. While this might work during development or for specific scenarios, it isn’t sufficient if the list of origins (or other permissions) needs to be determined dynamically (say, from a database).
Fortunately, the CORS framework in Web API is extensible such that supporting a dynamic list of origins is easy. In fact, the framework is so flexible that there are two general approaches for customizing the generation of policy.
**Custom CORS Policy Attribute** One approach to enable a dynamic CORS policy is to develop a custom attribute class that can generate the policy from some data source. This custom attribute class can be used instead of the EnableCorsAttribute class provided by Web API. This approach is simple and retains the fine-grained feel of being able to apply an attribute on specific classes and methods (and not apply it on others), as needed.
To implement this approach, you simply build a custom attribute similar to the existing EnableCorsAttribute class. The main focus is the ICorsPolicyProvider interface, which is responsible for creating an instance of a CorsPolicy for any given request. Figure 5 contains an example.
## Figure 5 A Custom CORS Policy Attribute
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,
                AllowMultiple = false)]
public class EnableCorsForPaidCustomersAttribute :
  Attribute, ICorsPolicyProvider
{
  public async Task<CorsPolicy> GetCorsPolicyAsync(
    HttpRequestMessage request, CancellationToken cancellationToken)
  {
    var corsRequestContext = request.GetCorsRequestContext();
    var originRequested = corsRequestContext.Origin;
    if (await IsOriginFromAPaidCustomer(originRequested))
    {
      // Grant CORS request
      var policy = new CorsPolicy
      {
        AllowAnyHeader = true,
        AllowAnyMethod = true,
      };
      policy.Origins.Add(originRequested);
      return policy;
    }
    else
    {
      // Reject CORS request
      return null;
    }
  }
  private async Task<bool> IsOriginFromAPaidCustomer(
    string originRequested)
  {
    // Do database look up here to determine if origin should be allowed
    return true;
  }
}
The CorsPolicy class has all the properties to express the CORS permissions to grant. The values used here are just an example, but presumably they could be populated dynamically from a database query (or from any other source).
**Custom Policy Provider Factory** The second general approach to building a dynamic CORS policy is to create a custom policy provider factory. This is the piece of the CORS framework that obtains the policy provider for the current request. The default implementation from Web API uses the custom attributes to discover the policy provider (as you saw earlier, the attribute class itself was the policy provider). This is another pluggable piece of the CORS framework, and you’d implement your own policy provider factory if you wanted to use an approach for policy other than custom attributes.
The attribute-based approach described earlier provides an implicit association from a request to a policy. A custom policy provider factory approach is different from the attribute approach because it requires your implementation to provide the logic to match the incoming request to a policy. This approach is more coarse-grained, as it’s essentially a centralized approach for obtaining a CORS policy.
**Figure 6** shows an example of what a custom policy provider factory might look like. The main focus in this example is the implementation of the ICorsPolicyProviderFactory interface and its GetCorsPolicyProvider method.
Figure 6 A Custom Policy Provider Factory
public class DynamicPolicyProviderFactory : ICorsPolicyProviderFactory
{
  public ICorsPolicyProvider GetCorsPolicyProvider(
    HttpRequestMessage request)
  {
    var route = request.GetRouteData();
    var controller = (string)route.Values["controller"];
    var corsRequestContext = request.GetCorsRequestContext();
    var originRequested = corsRequestContext.Origin;
    var policy = GetPolicyForControllerAndOrigin(
      controller, originRequested);
    return new CustomPolicyProvider(policy);
  }
  private CorsPolicy GetPolicyForControllerAndOrigin(
   string controller, string originRequested)
  {
    // Do database lookup to determine if the controller is allowed for
    // the origin and create CorsPolicy if it is (otherwise return null)
    var policy = new CorsPolicy();
    policy.Origins.Add(originRequested);
    policy.Methods.Add("GET");
    return policy;
  }
}
public class CustomPolicyProvider : ICorsPolicyProvider
{
  CorsPolicy policy;
  public CustomPolicyProvider(CorsPolicy policy)
  {
    this.policy = policy;
  }
  public Task<CorsPolicy> GetCorsPolicyAsync(
    HttpRequestMessage request, CancellationToken cancellationToken)
  {
    return Task.FromResult(this.policy);
  }
}
The main difference in this approach is that it’s entirely up to the implementation to determine the policy from the incoming request. In Figure 6, the controller and origin could be used to query a database for the policy values. Again, this approach is the most flexible, but it potentially requires more work to determine the policy from the request.
To use the custom policy provider factory, you must register it with Web API via the SetCorsPolicyProviderFactory extension method in the Web API configuration:
public static class WebApiConfig
{
  public static void Register(HttpConfiguration config)
  {
    // Other configuration omitted
    config.EnableCors();
    config.SetCorsPolicyProviderFactory(
      new DynamicPolicyProviderFactory());
  }
}
# Debugging CORS
A few techniques come to mind to debug CORS if (and when) your cross-origin AJAX calls aren’t working.
**Client Side** One approach to debugging is to simply use your HTTP debugger of choice (for example, Fiddler) and inspect all HTTP requests. Armed with the knowledge gleaned earlier about the details of the CORS specification, you can usually sort out why a particular AJAX request isn’t being granted permission by inspecting the CORS HTTP headers (or lack thereof).
Another approach is to use your browser’s F12 developer tools. The console window in modern browsers provides a useful error message when an AJAX calls fails due to CORS.
**Server Side** The CORS framework itself provides detailed trace messages using the tracing facilities of Web API. As long as an ITraceWriter is registered with Web API, the CORS framework will emit messages with information about the policy provider selected, the policy used, and the CORS HTTP headers emitted. For more information on Web API tracing, consult the Web API documentation on MSDN.
--- 
I want to emphasise that the above excerpt is not my work and is entirely attributable to Brock Allen of thinktecture.
  [1]: https://msdn.microsoft.com/en-us/magazine/dn532203.aspx
