	public List<Log> ViewItFilterUseCount()
	{
		var ndtms2Utils = new NDTMS2UtilsEntities();
		// Query LINQ-to-Entities database for all matching rows
		var valueQuery = ndtms2Utils.Logs.Where((o) => o.Message.StartsWith("ViewIt - View Data")).ToList();
		// Then process client-side
		int index = 0;
		return (from log in valueQuery
				group log by (index++ / 4) into grp
				let log = grp.Last()
				select new Log {
					Id = log.Id,
					Date = log.Date,
					Thread = log.Thread,
					Level = log.Level,
					Logger = log.Logger,
					Message = "ViewIt - View Data - the user has selected: " + string.Join(", ", grp.Select((l) => l.Message.Substring(l.Message.IndexOf(": ") + 2))),
					Exception = log.Exception
				}).ToList();
	}
