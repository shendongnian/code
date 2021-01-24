	public List<Log> ViewItFilterUseCount()
	{
		var ndtms2Utils = new NDTMS2UtilsEntities();
		return (from pack in ndtms2Utils.Logs.Where((o) => o.Message.StartsWith("ViewIt - View Data")).Select((o, i) => new{ Log=o, Idx=i })
				group pack.Log by (pack.Idx / 4) into grp
				let log = grp.OrderByDescending((o) => o.Id).First()
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
