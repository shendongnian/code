	var saveDir = Path.Combine(Path.GetTempPath(), "some_excel.xlsx");
	using (var client = new HttpClient())
	{
		var response = client.PostAsync(url, content).Result;
		if (response.IsSuccessStatusCode)
		{
			var content = response.Content.ReadAsByteArrayAsync().Result;
			File.WriteAllBytes(saveDir, content);
		}
	}
