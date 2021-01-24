	using (var client = new HttpClient())
	{
		var url = "https://graph.microsoft.com/v1.0" + $"/drives/{driveID}/items/{folderId}:/{originalFileName}:/content";
		client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GetAccessToken());
		byte[] sContents = System.IO.File.ReadAllBytes(filePath);
		var content = new ByteArrayContent(sContents);
		var response = client.PutAsync(url, content).Result.Content.ReadAsStringAsync().Result;
	}
