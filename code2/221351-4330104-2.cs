	namespace Repro
	{
		using System;
		using System.IO;
		using System.Net;
		using System.Net.Cache;
		using System.Text;
		class ReproProg
		{
			const string requestUrl = "http://drivelog.miracle.local:3030/users/current.json";
			// Manual construction of HTTP basic auth so we don't get an unnecessary server
			// roundtrip telling us to auth, which is what we get if we simply use
			// HttpWebRequest.Credentials.
			private static void SetAuthorization(HttpWebRequest request, string _username, string _password)
			{
				string userAndPass = string.Format("{0}:{1}", _username, _password);
				byte[] authBytes = Encoding.UTF8.GetBytes(userAndPass.ToCharArray());
				request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(authBytes);
			}
			static public void DoRequest()
			{
				var request = (HttpWebRequest) WebRequest.Create(requestUrl);
				request.Method = "GET";
				request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
				SetAuthorization(request, "user@domain.com", "12345678");
				using(var response = request.GetResponse())
				using(var stream = response.GetResponseStream())
				using(var reader = new StreamReader(stream))
				{
					string reply = reader.ReadToEnd();
					Console.WriteLine("########## Server reply: {0}", reply);
				}
			}
			static public void Main(string[] args)
			{
				DoRequest();	// works
				DoRequest();	// explodes
			}
		}
	}
