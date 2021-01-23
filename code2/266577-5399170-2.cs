	private Int64? GetContentIdOrNull(string id)
	{
		return string.IsNullOrEmpty(id) ? null : (Int64?)Convert.ToInt64(id);
	}
	
	private Int64? GetContentIdOrNull(DefaultIdType id)
	{
		return id;
	}
	
	private void InitContent()
	{
		// Attempt to get content from multiple sources in order of preference
		
		var contentSources = new Dictionary<ContentFrom, Func<Int64?>> {
			{ ContentFrom.Query,   () => GetContentIdOrNull(Request.QueryString["id"]) },
			{ ContentFrom.Default, () => GetContentIdOrNull(DefaultId) }
		};
		
		foreach (var source in contentSources) {
			var id = source.Value();
			if (id != null) {
				Content = GetContent(id);
				ContentMode = source.Key;
				return;
			}
		}
		// Default
		ContentMode = ContentFrom.None;
	}
