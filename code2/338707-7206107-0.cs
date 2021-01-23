    	public static void CallMethod<T>(string endPoint, Method method, Dictionary<string, object> parameters, Action<RestResponse<T>> callback) where T : new()
		{
			if (string.IsNullOrWhiteSpace(url))
				url = Settings.GetSetting("url");
			var client = new RestClient(url);
			var request = new RestRequest(endPoint, method);
			if (parameters == null) parameters = new Dictionary<string, object>();
			foreach (var parameter in parameters)
			{
				request.AddParameter(parameter.Key, parameter.Value);
			}
			client.ExecuteAsync(request, callback);
		}
