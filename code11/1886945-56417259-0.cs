csharp
public static IServiceCollection AddProtectedApiCallsWebApis(this IServiceCollection services, IConfiguration configuration, IEnumerable<string> scopes)
{
 ...
 services.Configure<JwtBearerOptions>(AzureADDefaults.JwtBearerAuthenticationScheme, options =>
 {
  options.Events.OnTokenValidated = async context =>
  {
   var tokenAcquisition = context.HttpContext.RequestServices.GetRequiredService<ITokenAcquisition>();
   context.Success();
   // Adds the token to the cache, and also handles the incremental consent and claim challenges
   tokenAcquisition.AddAccountToCacheFromJwt(context, scopes);
   await Task.FromResult(0);
  };
 });
 return services;
}
csharp
private async Task GetTodoList(bool isAppStarting)
{
 ...
 //
 // Get an access token to call the To Do service.
 //
 AuthenticationResult result = null;
 try
 {
  result = await _app.AcquireTokenSilent(Scopes, accounts.FirstOrDefault())
                     .ExecuteAsync()
                     .ConfigureAwait(false);
 }
...
// Once the token has been returned by MSAL, add it to the http authorization header, before making the call to access the To Do list service.
_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);
// Call the To Do list service.
HttpResponseMessage response = await _httpClient.GetAsync(TodoListBaseAddress + "/api/todolist");
...
}
