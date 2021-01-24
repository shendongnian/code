    using CleanREC0.Application.Common.Interfaces;
    using Microsoft.AspNetCore.Http;
    using System.Security.Claims;
    
    namespace CleanREC0.WebUI.Services
    {
        public class CurrentUserService : ICurrentUserService
        {
            private IHttpContextAccessor _httpContextAccessor;
    
            public CurrentUserService(IHttpContextAccessor httpContextAccessor)
            {
                _httpContextAccessor = httpContextAccessor;
            }
    
            public string UserId { get { return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier); }}
        }
    }
