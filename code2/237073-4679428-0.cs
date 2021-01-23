		static void Main(string[] args) {
			var webRequest = (HttpWebRequest)HttpWebRequest.Create("https://graph.facebook.com/oauth/access_token");
			webRequest.Method = "POST";
			webRequest.ContentType = "application/x-www-form-urlencoded";
			var requestString = "grant_type=client_credentials&client_id=***client_secret=***";
			byte[] bytedata = Encoding.UTF8.GetBytes(requestString);
			webRequest.ContentLength = bytedata.Length;
			var requestStream = webRequest.GetRequestStream();
			requestStream.Write(bytedata, 0, bytedata.Length);
			requestStream.Close();
			var response = webRequest.GetResponse();
			var responseStream = new StreamReader(response.GetResponseStream());
			var responseString = responseStream.ReadToEnd();
			responseStream.Close();
			response.Close();
			if (!String.IsNullOrWhiteSpace(responseString)) {
				var accessToken = responseString.Replace("access_token=", "");
				var fbApp = new FacebookApp(accessToken);
				long id = ****;
				dynamic results = fbApp.Query("select name, email, website from user where uid=" + id.ToString());
				dynamic user = results[0];
				Console.Write(String.Concat(user.name, " ", user.email, " ", user.website));
			}
			else {
			}
			Console.ReadLine();
		}
