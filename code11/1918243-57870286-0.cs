    public static void PostSomething()
	{
		var url = "http://localhost:5591/api/values";
        using (var client = new HttpClient())
        {
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(AddContentDispositionParam("name", "val1"));
                formData.Add(AddContentDispositionParam("name", "val2"));
                try
                {
                    var response = client.PostAsync(url, formData).Result;
                }
                catch (Exception e)
                {
                }
            }
        }
	}
	
	public static StringContent AddContentDispositionParam(string name, string value)
    {
        var stringContent = new StringContent(value, Encoding.UTF8);
        stringContent.Headers.Add("Content-Disposition", $"form-data; name=\"{name}\"");
        return stringContent;
    }
