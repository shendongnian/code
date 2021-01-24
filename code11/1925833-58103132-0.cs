	static async Task TryDownload()
	{
		var clientHandler = new HttpClientHandler
		{
			AllowAutoRedirect = true,
			UseCookies = true,
			CookieContainer = new CookieContainer()
		};
		using (var httpClient = new HttpClient(clientHandler))
		{
			// this gets the request and allows the site to set cookies.
			var warmup = await httpClient.GetAsync("https://www.fapiis.gov/fapiis/allfapiisdata.action");
			// get the file (cookies are sent automatically).
			var fileResponse = httpClient.GetAsync("https://www.fapiis.gov/fapiis/downloadview?type=allFapiis");
			if (fileResponse.Result.IsSuccessStatusCode)
			{
				HttpContent content = fileResponse.Result.Content;
				var contentStream = await content.ReadAsStreamAsync();
				using (var fileStream = File.Create("C:\\temp\\a.xlsx"))
				{
					contentStream.CopyTo(fileStream);
				}
			}
		}
	}
 
