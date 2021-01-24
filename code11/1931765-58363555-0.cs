    public class Startup
    {
        private CookieAuthenticationOptions _storedOption;
    
  
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication()
                .AddCookie(option =>
                {
                    _storedOption = option;
                });
        }
    
    
        public AuthenticationTicket Decrypt(HttpContext context, string cookie)
        {
            AuthenticationTicket ticket = _storedOption.TicketDataFormat.Unprotect(cookie, GetTlsTokenBinding(context));
            return ticket;
        }
    
        private string GetTlsTokenBinding(HttpContext context)
        {
            var binding = context.Features.Get<ITlsTokenBindingFeature>()?.GetProvidedTokenBindingId();
            return binding == null ? null : Convert.ToBase64String(binding);
        }
    }
