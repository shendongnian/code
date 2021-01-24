    public class IndexModel : BasePageModel {
        public IndexModel(IAuthorizationService authService) : base (authService) {
            //...
        }
        public async Task<ActionResult> OnGet() {
            if (!HasAccess("PermissionName")) {
                return new ForbidResult();
            }
            return Page();
        }
    }
    
