	private void InitContent()
	{
		// Attempt to get content from multiple sources in order of preference
	
		if (!String.IsNullOrEmpty(Request.QueryString["id"]))
		{
			Content = GetContent(Convert.ToInt64(Request.QueryString["id"]));
			ContentMode = ContentFrom.Query;
			return;
		}
		if (DefaultId != null)
		{
			Content = GetContent(DefaultId);
			ContentMode = ContentFrom.Default;
			return;
		}
		// Default
		ContentMode = ContentFrom.None;
	}
