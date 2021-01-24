    using (var client = new HttpClient())
    {
    	using (var formData = new MultipartFormDataContent())
    	{
    		formData.Add(new StreamContent(File.Open("test.txt", FileMode.Open)), "filedata", "test.txt");
    		formData.Add(new StringContent("mysiteid"), "siteid");
    		formData.Add(new StringContent("mycontainerid"), "containerid");
    		formData.Add(new StringContent("/"), "uploaddirectory");
    		formData.Add(new StringContent("test"), "description");
    		formData.Add(new StringContent("cm:content"), "contenttype");
    		formData.Add(new StringContent("true"), "overwrite");
    
    		var response = client.PostAsync("http://YOURALFRESCOHOST/alfresco/service/api/upload?alf_ticket=TICKET_XXXXXXXXXXXXXXXXXXXXXXXXX", formData).Result;
    
    		string result = null;
    		if (response.Content != null)
    		{
    			result = response.Content.ReadAsStringAsync().Result;
    		}
    
    		if (response.IsSuccessStatusCode)
    		{
    			if (string.IsNullOrWhiteSpace(result))
    				result = "Upload successful!";
    		}
    		else
    		{
    			if (string.IsNullOrWhiteSpace(result))
    				result = "Upload failed for unknown reason";
    		}
    		
    		Console.WriteLine($"Result is: {result}");
    	}
    }
