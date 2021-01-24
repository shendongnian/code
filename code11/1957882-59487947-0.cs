	string url = "https://i.imgur.com/0acC9nr.png";
	var client = new HttpClient();
	var imageData = client.GetByteArrayAsync(url).Result;
	
	var content = new MultipartFormDataContent();
	string fileName = new Uri(url).LocalPath.Replace("/", "");
	content.Add(new ByteArrayContent(imageData), "file", fileName);
    // Optionally when the Content-Type body field is required
	// content.ElementAt(0).Headers.ContentType = MediaTypeHeaderValue.Parse("image/png");
	var postResp = client.PostAsync("https://my-image-hoster/api.php", content).Result;
	var resp = postResp.Content.ReadAsStringAsync().Result;
