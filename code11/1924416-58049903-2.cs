	[HttpGet]
	public async Task<IHttpActionResult> GetCompanies(
		int pageIndex,
		int pageSize,
		string orderBy,
		OrderByDirection orderByDirection,
		string filters)
	{
	...
	}
	
