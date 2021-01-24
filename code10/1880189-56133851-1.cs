<sessionState mode="inProc" timeout="30" ></sessionState>
Try to read from HttpContext
var name  = (string)System.Web.HttpContext.Current.Session["Name"];
// the assignment for email is User as you referred?
var email = (string)System.Web.HttpContext.Current.Session["User"];
**Edited**
check if you are using any of this and are destroying your session
Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
Response.Cache.SetCacheability(HttpCacheability.NoCache);
Response.Cache.SetNoStore();
Session.Abandon();
Session.Clear();
