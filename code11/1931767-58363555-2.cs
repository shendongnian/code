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
        public string DecryptRaw(HttpContext context, string cookie)
        {
            IDataProtectionProvider dataProtectionProvider = _storedOption.DataProtectionProvider;
            IDataProtector protector = dataProtectionProvider.CreateProtector("Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware", "Identity.Application", "v2");
            string purpose = GetTlsTokenBinding(context);
            if (!string.IsNullOrEmpty(purpose))
            {
                protector = protector.CreateProtector(purpose);
            }
            var protectedData = Base64UrlTextEncoder.Decode(cookie);
            byte[] userData = protector.Unprotect(protectedData);
            var rawText = Encoding.UTF8.GetString(userData);
            return rawText;
        }
    
        private string GetTlsTokenBinding(HttpContext context)
        {
            var binding = context.Features.Get<ITlsTokenBindingFeature>()?.GetProvidedTokenBindingId();
            return binding == null ? null : Convert.ToBase64String(binding);
        }
    }
