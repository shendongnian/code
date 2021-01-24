    Expression<Func<Service, bool>> servicesWhereClause;
			if (!userType.HasValue)
				servicesWhereClause = x => x.Status == Service.ServiceStatus.Published;
			else
				servicesWhereClause = x => x.Status == Service.ServiceStatus.Published
					&& x.UserType == userType.Value;
			var result = _dbContext.Institution
				.Include(a => a.Services)
				.Where(a => a.Id == institutionId)
				.Select(i => new
				{
					Institution = i,
					Services = i.Services.Where(servicesWhereClause)
				})
				.ToList()
				.Select(anon => new Institution
				{
					Id = anon.Id,
					Name = anon.Name,
					// etc...
					Services = anon.Services
				})
				.ToList();
