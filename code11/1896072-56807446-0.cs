if (context.Resource is AuthorizationFilterContext filterContext)
 - The User may not have the claim. In addition to what is mentioned in the comments, the user may or may not have the claim even if they are authenticated. My preferred access pattern for this is null-conditional access with first or default linq.
var primarySid = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value
 -  The PrimarySid claim may or may not be an int. You might not set a string as the PrimarySid on purpose but bugs happen or a malicious user might.
if (!int.TryParse(primarySid, out var registoId))
 - Optional, since the method returns a Task, you can perform an asynchronous database lookup which scales better and has the added side-benefit of not needing to return Completed Tasks every time you return. 
Putting this all together,
protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, IsParagemNotOnGoingRequirement requirement)
{
    var user = context.User;
    if (!user.Identity.IsAuthenticated)
    {
        return;
    }
    var primarySid = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value
    if (string.IsNullorWhiteSpace(primarySid)) 
    {
        return;
    }
    
    int registoId;
    if (!int.TryParse(rawUserId, out registoId)) 
    {
        return;
    }
    bool IsRegistoOnGoing = await _context.ParagensRegistos
                  .AnyAsync(pr => pr.RegistoId == registoId && pr.HoraFim == null);
    if (!IsRegistoOnGoing)
    {
        context.Succeed(requirement); // success!!
    }
    else
    {
        if (context.Resource is AuthorizationFilterContext filterContext)
        {
             filterContext.Result = new RedirectToPageResult("/Paragem");
        }     
        context.Succeed(requirement); // success here again?
    }
}
Also, your requirement succeeds regardless of whether the condition is true or false and  you have performed a side-effect inside your authorisation handler which is to fire a redirect. This is not how it is supposed to work. You are supposed to fail or succeed requirement which in turn leads to a redirect that you have configured elsewhere. When your conditions mean nothing and you mix concerns and violate the [separation of concerns principle][1], your application is going to be hard to maintain.
Provided that you stick with this architecture, you can shorten the final if to,
    if (IsRegistoOnGoing && context.Resource is AuthorizationFilterContext filterContext)
    {
        filterContext.Result = new RedirectToPageResult("/Paragem");
    }
    context.Succeed(requirement);
I highly recommend a code review once you straighten out the possible exceptions.
  [1]: https://en.wikipedia.org/wiki/Separation_of_concerns
