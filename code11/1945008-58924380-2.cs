        private readonly IHttpContextAccessor HttpContextAccessor;
        public LoginModel(ISiteUserService siteUserService, 
            IHttpContextAccessor httpContextAccessor)
        {
            this.HttpContextAccessor = httpContextAccessor;        
        }
		public IActionResult OnGet()
        {
            if(HttpContextAccessor.HttpContext.Session.GetString("UserRole")!= null)
            {
