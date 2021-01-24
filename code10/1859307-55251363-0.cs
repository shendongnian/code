If you want the synchronous work to happen in a background thread, you can execute it using Task.Run as follows:
	private async Task FillTimes()
	{
		return Task.Run(() => {
		{
			var strResponse = CallJson($"RESTAPI URL");
			if (strResponse != null)
			{
				var jResult = JsonConvert.DeserializeObject<JsonResults>(strResponse);
				BindingSource bsResults = new BindingSource();
				bsResults.DataSource = jResult.Results;
				if (bsResults.DataSource != null)
				{
					DgvOnline.DataSource = bsResults.DataSource;
				}
			}
		}
	}
    
