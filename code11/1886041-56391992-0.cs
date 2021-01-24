c#
using System;
using System.Web;
using System.Web.Mvc;
/// <summary>
/// Authorises User based on what domain they are on.
/// </summary>
public class AuthorizeDomainAttribute : AuthorizeAttribute
{
    /// <summary>
    /// List of domains to authorise
    /// </summary>
    public string[] Domains { get; set; }
    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {
        if (httpContext == null)
        {
            throw new ArgumentNullException("httpContext");
        }
        // Get the domain part of the username
        string userDomain = httpContext.User.Identity.Name.Substring(0, httpContext.User.Identity.Name.LastIndexOf('\\'));
        // Check if the user is on any of the domains specified
        foreach(string domain in this.Domains)
        {
            if (userDomain == domain)
            {
                return true;
            }
        }
        // Otherwise don't authenticate them
        return false;
    }
}
And then using this attribute on my controller.
c#
[AuthorizeDomain(Domains = new[] { "VSD-PROMETHEUS")]
