	using (var client = new HttpClient())
	{
		var url = "https://graph.microsoft.com/v1.0" + $"/drives/{driveID}/items/{folderId}:/{originalFileName}:/createUploadSession";
		client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GetAccessToken());
		var sessionResponse = client.PostAsync(apiUrl, null).Result.Content.ReadAsStringAsync().Result;
		byte[] sContents = System.IO.File.ReadAllBytes(filePath);
		var uploadSession = JsonConvert.DeserializeObject<UploadSessionResponse>(sessionResponse);
		string response = UploadFileBySession(uploadSession.uploadUrl, sContents);
	}
