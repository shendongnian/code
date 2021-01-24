    public class IdentityServerEventSink : IEventSink
    {
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly UserManager<IdentityUser> _userManager;
    
            public IdentityServerEventSink(IHttpContextAccessor httpContextAccessor,
                                           UserManager<IdentityUser> userManager)
            {
                _httpContextAccessor = httpContextAccessor;
                _userManager = userManager;
            }
    
            public async Task PersistAsync(Event @event)
            {
                if (@event.Id.Equals(EventIds.ClientAuthenticationFailure) || @event.Id.Equals(EventIds.TokenIssuedSuccess) || @event.Id.Equals(EventIds.TokenIssuedFailure))
                {
                    Identity user = null;
    
                    try
                    {
                        user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
    
                        if (user != null)
                        {
                           // do stuff
                        }
                    }
                    catch (Exception ex)
                    {
                      // handle exception
                    }
                }
            }
    }
