	public static async Task<String> MakeRequestAsync(String url)
	{
		return await
			Observable.Using(
				() => new WebClient(),
				wc => Observable.Start(() => wc.DownloadString(url)));
	}
