    	private void MakeACall(int someValue)
		{
			var parameters = new Dictionary<string, object> { { "paramOne", someValue }, { "paramTwo", SomeLocalMethod()} };
			RestAPI.CallMethod<GroupDto>("/Service/Operation", Method.POST, parameters, CallbackMethod);
		}
		private void CallbackMethod(RestResponse<GroupDto> response)
		{
			if (response.StatusCode != HttpStatusCode.OK)
				return;
    		...
