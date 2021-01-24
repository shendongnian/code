`
using System;
using System.Linq;
using System.Web;
namespace SameSiteHttpModule
{
    public class SameSiteDoomsdayModule : IHttpModule
    {
        /// <summary>
        ///     Set up the event handlers.
        /// </summary>
        public void Init(HttpApplication context)
        {
            // This one is the OUTBOUND side; we add the extra cookie
            context.PreSendRequestHeaders += OnEndRequest;
            // This one is the INBOUND side; we coalesce the cookies.
            context.BeginRequest += OnBeginRequest;
        }
        /// <summary>
        ///     The OUTBOUND LEG; we add the extra cookie.
        /// </summary>
        private void OnEndRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            // IF NEEDED: Add URL filter here
            for (int i = 0; i < context.Response.Cookies.Count; i++)
            {
                HttpCookie responseCookie = context.Response.Cookies[i];
                context.Response.Headers.Add("Set-Cookie", $"{responseCookie.Name}-same-site={responseCookie.Value};SameSite=None; Secure");
            }
        }
        /// <summary>
        ///     The INBOUND LEG; we coalesce the cookies.
        /// </summary>
        private void OnBeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            // IF NEEDED: Add URL filter here
            string[] keys = context.Request.Cookies.AllKeys;
            for (int i = 0; i < context.Request.Cookies.Count; i++)
            {
                HttpCookie inboundCookie = context.Request.Cookies[i];
                if (!inboundCookie.Name.Contains("-same-site"))
                {
                    continue; // Not interested in this cookie.
                }
                // Check to see if we have a root cookie without the -same-site
                string actualName = inboundCookie.Name.Replace("-same-site", string.Empty);
                if (keys.Contains(actualName))
                {
                    continue; // We have the actual key, so we are OK; just continue.
                }
                // We don't have the actual name, so we need to inject it as if it were the original
                // https://support.microsoft.com/en-us/help/2666571/cookies-added-by-a-managed-httpmodule-are-not-available-to-native-ihtt
                // HttpCookie expectedCookie = new HttpCookie(actualName, inboundCookie.Value);
                context.Request.Headers.Add("Cookie", $"{actualName}={inboundCookie.Value}");
            }
        }
        public void Dispose()
        {
            
        }
    }
}
`
This gets installed like any other HTTP module:
`
<?xml version="1.0" encoding="utf-8"?>
<configuration>    
    <system.webServer>
        <modules>
            <add type="SameSiteHttpModule.SameSiteDoomsdayModule, SameSiteHttpModule" name="SameSiteDoomsdayModule"/>
        </modules>
        <handlers>        
            <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModule" resourceType="Unspecified" />
        </handlers>
        <aspNetCore processPath=".\IC.He.IdentityServices.exe" arguments="" forwardWindowsAuthToken="false" requestTimeout="00:10:00" stdoutLogEnabled="false" stdoutLogFile=".\logs\stdout" />
    </system.webServer>
</configuration>
`
You can find more info here: https://charliedigital.com/2020/01/22/adventures-in-single-sign-on-samesite-doomsday/
It will provide the fix for ANY .NET version, ANY .NET Core version, ANY scenario whether you own the original source code or not.
