    protected override AuthenticationResult VerifyAuthenticationCore(AuthorizedTokenResponse response)
		{
			string username;
			var accessToken = response.AccessToken;
			var userId = response.ExtraData["encoded_user_id"];
			var httpWebRequest = WebWorker.PrepareAuthorizedRequest(new MessageReceivingEndpoint(new Uri("http://api.fitbit.com/1/user/" + userId + "/profile.json"), HttpDeliveryMethods.AuthorizationHeaderRequest | HttpDeliveryMethods.GetRequest), accessToken);
			var dictionary = new Dictionary<string, string>();
			dictionary.Add("accesstoken", accessToken);
			dictionary.Add("link", "http://www.fitbit.com/user/" + userId);
			using (var webResponse = httpWebRequest.GetResponse())
			{
				using (var stream = webResponse.GetResponseStream())
				using (var reader = new StreamReader(stream))
				{
					var profile = JObject.Parse(reader.ReadToEnd())["user"];
					dictionary.AddItemIfNotEmpty("name", profile["displayName"]);
					dictionary.AddItemIfNotEmpty("pictureUrl", profile["avatar"]);
					username = dictionary["name"];
				}
			}
			return new AuthenticationResult(true, ProviderName, userId, username, dictionary);
		}
