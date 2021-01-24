    public abstract class BasePageModel : PageModel {
        protected readonly IAuthorizationService authService;
        protected BasePageModel(IAuthorizationService authService) {
            this.authService = authService;
        }
        
        protected async Task<bool> HasAccess(string permissionName) {
            return (await authService.AuthorizeAsync(User, permissionName)).Succeeded;
        }
    }
    
