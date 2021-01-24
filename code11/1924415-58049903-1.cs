	[HttpGet]
	[Route("Contacts")]
	public async Task<IHttpActionResult> GetCompaniesAndContacts(
		int pageIndex,
		int pageSize,
		string orderBy,
		OrderByDirection orderByDirection,
		string filters)
	{
	...
	}	
