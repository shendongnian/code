	public async Task Index(int projectId, string period)
	{
		await Generate(projectId, DateTime.Parse(period), fs =>
		{
			if (fs != null)
			{
				fs.Seek(0, SeekOrigin.Begin);
				return File(fs, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "kpi.xlsx");
			}
		});
	}
	
