    var data = new List<string>(new[]
		{
			"2019-01-12 Meeting minutes.pdf",
			"Safeguarding policy.pdf",
			"2017-04-27 Meeting minutes.pdf",
			"2018-06-02 Meeting minutes.pdf",
			"2017-12-13 Meeting agenda.pdf",
			"Privacy policy.pdf",
			"Welfare policy.pdf",
			"2018-11-19 Meeting agenda.pdf"
		});
	var parsedData = data.Select(d => new ParsedFilename(d));
	var sortedData = parsedData.OrderByDescending(d => d.Date)
                               .ThenBy(d => d.Name);
	var output = sortedData.Select(d => d.FullName);
