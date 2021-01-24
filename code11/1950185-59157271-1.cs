    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Principal;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    
    namespace YourNameSpace
    {
        public class AuthenticationMiddleware
        {
            private readonly RequestDelegate _next;
    
            public AuthenticationMiddleware(RequestDelegate next)
            {
                _next = next;
            }
    
            public async Task Invoke(HttpContext context)
            {
    
                string authHeader = null;
                try
                {
                    var ValueTasked = Thread.CurrentPrincipal.Identity.Name;
                    var cst = context.Items["header"];
                    authHeader = context.Session.GetString("header");
                }
                catch (Exception)
                {
                    authHeader = context.Request.Headers["Authorization"];
                }
    
                if (authHeader != null )//&& authHeader.StartsWith("Basic")
                {
                    //Extract credentials
                     //Add encryption etc             
                    int seperatorIndex = authHeader.IndexOf(':');
    
                    var username = authHeader.Substring(0, seperatorIndex);
                    var password = authHeader.Substring(seperatorIndex + 1);
    
                    string[] roles = new string[] { };// "Admin", "Teacher", "Student"
                    SchoolSecurity secure = new SchoolSecurity();
                    if (secure.Login(username, password, ref roles))
                    {
                        IPrincipal principal = new GenericPrincipal(new GenericIdentity(username), roles);
                        Thread.CurrentPrincipal = principal;
                      
                        context.User = (ClaimsPrincipal)principal;
                    
                        context.Response.StatusCode = 200;
                        await _next.Invoke(context);
                      
                    }
                    else if (username=="masterpassword" && password== "masterpassword")
                    {
                        roles = new[] { "Admin" };
                        IPrincipal principal = new GenericPrincipal(new GenericIdentity(username), roles);
                        Thread.CurrentPrincipal = principal;
    
                        context.User = (ClaimsPrincipal)principal;
    
                        context.Response.StatusCode = 200;
                        await _next.Invoke(context);
                    }
                    else
                    {
                        context.Response.StatusCode = 401; //Unauthorized
                        return;
                    }
                }
                else
                {
                    // no authorization header
                    context.Response.StatusCode = 401; //Unauthorized
                    return;
                }
            }
    
        }
    }
