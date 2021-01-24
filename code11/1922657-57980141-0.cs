	var query = db.vw_web_GetAccounts as IQueryable<vw_web_GetAccounts>;
	if (some condition)
	{
		query = query.Where(...);
	}
	else
	{
		query = query.Where(...);
	}
	return query.Select(a =>  new AccountVM
	{
		Name = a.Name,
		....
	}).ToList();
