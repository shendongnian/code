    class C2DMPrototype
	{
		// Hardcoded for now
		private static readonly string RegistrationId = "XXXXXXXXXXX";
		private static readonly string GoogleAuthUrl = "https://www.google.com/accounts/ClientLogin";
		// TODO : Production code should use https (secure) push and have the correct certificate
		private static readonly string GoogleMessageUrl = "http://android.clients.google.com/c2dm/send";
		private static readonly string PostWebRequest = "POST";
		private static readonly string AuthTokenHeader = "Auth=";
		private static readonly string UpdateClientAuth = "Update-Client-Auth";
		// Post data parameters
		private static readonly string RegistrationIdParam = "registration_id";
		private static readonly string CollapseKeyParam = "collapse_key";
		private static readonly string DataPayloadParam = "data.payload";
		private static readonly string DelayWhileIdleParam = "delay_while_idle";
		private string _authTokenString = String.Empty;
		private string _updatedAuthTokenString = String.Empty;
		private string _message = String.Empty;
		public void StartServer()
		{
			if ((_authTokenString = GetAuthentificationToken()).Equals(String.Empty))
			{
				Console.ReadLine();
				return;
			}
			while (true)
			{
				try
				{
					Console.Write("Message> ");
					_message = Console.ReadLine().ToLower().Trim();
					SendMessage(_authTokenString, RegistrationId, _message);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					Console.WriteLine(ex.StackTrace);
				}
			}
		}
		private static string GetAuthentificationToken()
		{
			string authTokenString = String.Empty;
			try
			{
				WebRequest request = WebRequest.Create(GoogleAuthUrl);
				request.Method = PostWebRequest;
				NameValueCollection postFieldNameValue = new NameValueCollection();
				postFieldNameValue.Add("Email", "XXXXXXXXXXX");
				postFieldNameValue.Add("Passwd", "XXXXXXXXXXX");
				postFieldNameValue.Add("accountType", "GOOGLE");
				postFieldNameValue.Add("source", "Google-cURL-Example");
				postFieldNameValue.Add("service", "ac2dm");
				string postData = GetPostStringFrom(postFieldNameValue);
				byte[] byteArray = Encoding.UTF8.GetBytes(postData);
				request.ContentType = "application/x-www-form-urlencoded";
				request.ContentLength = byteArray.Length;
				Stream dataStream = request.GetRequestStream();
				dataStream.Write(byteArray, 0, byteArray.Length);
				dataStream.Close();
				WebResponse response = request.GetResponse();
				if (((HttpWebResponse)response).StatusCode.Equals(HttpStatusCode.OK))
				{
					dataStream = response.GetResponseStream();
					StreamReader reader = new StreamReader(dataStream);
					string responseFromServer = reader.ReadToEnd();
					authTokenString = ParseForAuthTokenKey(responseFromServer);
					reader.Close();
					dataStream.Close();
				}
				else
				{
					Console.WriteLine("Response from web service not OK :");
					Console.WriteLine(((HttpWebResponse)response).StatusDescription);
				}
				response.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Getting Authentication Failure");
				Console.WriteLine(ex.Message);
			}
			return authTokenString;
		}
		private static void SendMessage(string authTokenString, string registrationId, string message)
		{
			//Certeficate was not being accepted for the sercure call
			//ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateServerCertificate);
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GoogleMessageUrl);
			request.Method = PostWebRequest;
			request.KeepAlive = false;
			NameValueCollection postFieldNameValue = new NameValueCollection();
			postFieldNameValue.Add(RegistrationIdParam, registrationId);
			postFieldNameValue.Add(CollapseKeyParam, "0");
			postFieldNameValue.Add(DelayWhileIdleParam, "0");
			postFieldNameValue.Add(DataPayloadParam, message);
			string postData = GetPostStringFrom(postFieldNameValue);
			byte[] byteArray = Encoding.UTF8.GetBytes(postData);
			request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
			request.ContentLength = byteArray.Length;
			request.Headers.Add(HttpRequestHeader.Authorization, "GoogleLogin auth=" + authTokenString);
			Stream dataStream = request.GetRequestStream();
			dataStream.Write(byteArray, 0, byteArray.Length);
			dataStream.Close();
			WebResponse response = request.GetResponse();
			HttpStatusCode responseCode = ((HttpWebResponse)response).StatusCode;
			if (responseCode.Equals(HttpStatusCode.Unauthorized) || responseCode.Equals(HttpStatusCode.Forbidden))
			{
				Console.WriteLine("Unauthorized - need new token");
			}
			else if (!responseCode.Equals(HttpStatusCode.OK))
			{
				Console.WriteLine("Response from web service not OK :");
				Console.WriteLine(((HttpWebResponse)response).StatusDescription);
			}
			StreamReader reader = new StreamReader(response.GetResponseStream());
			string responseLine = reader.ReadLine();
			reader.Close();
		}
		private static string GetPostStringFrom(NameValueCollection nameValuePair)
		{
			StringBuilder postString = new StringBuilder();
			for (int i = 0; i < nameValuePair.Count; i++)
			{
				postString.Append(nameValuePair.GetKey(i));
				postString.Append("=");
				postString.Append(Uri.EscapeDataString(nameValuePair[i]));
				if (i + 1 != nameValuePair.Count)
				{
					postString.Append("&");
				}
			}
			return postString.ToString();
		}
		private static string ParseForAuthTokenKey(string webResponse)
		{
			string tokenKey = String.Empty;
			if (webResponse.Contains(AuthTokenHeader))
			{
				tokenKey = webResponse.Substring(webResponse.IndexOf(AuthTokenHeader) + AuthTokenHeader.Length);
				if (tokenKey.Contains(Environment.NewLine))
				{
					tokenKey.Substring(0, tokenKey.IndexOf(Environment.NewLine));
				}
			}
			return tokenKey.Trim();
		}
		public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			// Return "true" to force the certificate to be accepted.
			return true;
		}
	}
