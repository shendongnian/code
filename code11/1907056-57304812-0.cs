    [BindProperties]
    public class LoginModel : PageModel {
        public string ReturnUrl { get; set; }
        public bool EnableLocalLogin { get; set; } = true;
        public string Username { get; set; }
        public string Password { get; set; }
    
        private readonly IIdentityServerInteractionService _interaction;
    
        public LoginModel(IIdentityServerInteractionService interaction)
        {
            _interaction = interaction;
        }
    
        public IActionResult OnGet(string returnUrl)
        {            
            ReturnUrl = returnUrl;
            return Page();
        }
    
        public IActionResult OnPost(string button) {
            //access properties here which should be populated from form.
            // todo - implement
            return Page();
        }
    }
