public class BasicAuthHttpModule: IHttpModule {
 public void Init(HttpApplication context) {
  context.AuthenticateRequest += OnApplicationAuthenticateRequest;
  context.EndRequest += OnApplicationEndRequest;
 }
 private static void OnApplicationAuthenticateRequest(object sender, EventArgs e) {
  var request = HttpContext.Current.Request;
  var authHeader = request.Headers["Authorization"];
  if (authHeader != null) {
   var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);
   if (authHeaderVal.Scheme.Equals("basic",
     StringComparison.OrdinalIgnoreCase) &&
    authHeaderVal.Parameter != null) {
    AuthenticateUser(authHeaderVal.Parameter);
   }
  }
 }
 private static bool AuthenticateUser(string credentials) {
  var encoding = Encoding.GetEncoding("iso-8859-1");
  credentials = encoding.GetString(Convert.FromBase64String(credentials));
  var credentialsArray = credentials.Split(':');
  string userCode = credentialsArray[0];
  string password = credentialsArray[1];
  var user = _userService.GetByUsernameAndPassword(username, password);
  if (user == null)
   return false;
  var identity = new GenericIdentity(user.Username);
  SetPrincipal(new GenericPrincipal(identity, new [] {
   user.Role.ToString()
  }));
  Globals.CurrentUser = user;
  return true;
 }
}
Example of use below;
[ApiController]
[Route("[controller]")]
public class UsersController: ControllerBase {
 [Authorize(Role.Admin)]
 [HttpGet]
 public IActionResult GetAll() {
  return Ok();
 }
referans:https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/basic-authentication
