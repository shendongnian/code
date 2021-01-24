    private readonly IHttpContextAccessor httpContextAccessor;
    public MyController(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }
	public IActionResult PerfilSocio( HttpContext contexto,int? id)
    {
        int x = Convert.ToInt32(httpContextAccessor.HttpContext.Session.GetInt32("UserId"))
