     //delete session cookie
     Session.Abandon();
     Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
     //create new sessionID
     SessionIDManager manager = new SessionIDManager();
     manager.RemoveSessionID(System.Web.HttpContext.Current);
     var newId = manager.CreateSessionID(System.Web.HttpContext.Current);
     var isRedirected = true;
     var isAdded = true;
     manager.SaveSessionID(System.Web.HttpContext.Current, newId, out isRedirected, out isAdded);
     //redirect so that the response.cookies call above actually enacts
     Response.Redirect("/account/logon");
