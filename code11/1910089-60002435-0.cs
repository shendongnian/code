    		public async Task<bool> PostIssueAsync(string userpass, string data)
		{
			HttpClient httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri(Constants.JiraUrl + "rest/api/latest/issue");
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", userpass);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			var content = new StringContent(data, Encoding.UTF8, "application/json");
			content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			try
			{
				var response = await httpClient.PostAsync(httpClient.BaseAddress, content);
				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return false;
			}
		}
