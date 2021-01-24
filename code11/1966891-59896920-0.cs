    private readonly IHttpContextAccessor httpContextAccessor;
    ...
	public IActionResult PerfilSocio( HttpContext contexto,int? id)
    {
        int x = Convert.ToInt32(httpContextAccessor.HttpContext.Session.GetInt32("UserId"))
