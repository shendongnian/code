	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.OleDb;
	using System.IO;
	using System.Linq;
	using System.Net.Http;
	using System.Text;
	using System.Threading.Tasks;
	using System.Web.Script.Serialization;
	namespace ConsoleApplication1
	{
		class Customer
		{
			public string Name { get; set; }
			public string Address { get; set; }
			public string Phone { get; set; }
		}
		public class Program
		{
			private static readonly HttpClient _Client = new HttpClient();
			private static JavaScriptSerializer _Serializer = new JavaScriptSerializer();
			static void Main(string[] args)
			{
				Run().Wait();
			}
			static async Task Run()
			{
				string url = "http://www.example.com/api/Customer";
				Customer cust = new Customer() { Name = "Example Customer", Address = "Some example address", Phone = "Some phone number" };
				var json = _Serializer.Serialize(cust);
				var response = await Request(HttpMethod.Post, url, json, new Dictionary<string, string>());
				string responseText = await response.Content.ReadAsStringAsync();
				List<YourCustomClassModel> serializedResult = _Serializer.Deserialize<List<YourCustomClassModel>>(responseText);
				Console.WriteLine(responseText);
				Console.ReadLine();
			}
			/// <summary>
			/// Makes an async HTTP Request
			/// </summary>
			/// <param name="pMethod">Those methods you know: GET, POST, HEAD, etc...</param>
			/// <param name="pUrl">Very predictable...</param>
			/// <param name="pJsonContent">String data to POST on the server</param>
			/// <param name="pHeaders">If you use some kind of Authorization you should use this</param>
			/// <returns></returns>
			static async Task<HttpResponseMessage> Request(HttpMethod pMethod, string pUrl, string pJsonContent, Dictionary<string, string> pHeaders)
			{
				var httpRequestMessage = new HttpRequestMessage();
				httpRequestMessage.Method = pMethod;
				httpRequestMessage.RequestUri = new Uri(pUrl);
				foreach (var head in pHeaders)
				{
					httpRequestMessage.Headers.Add(head.Key, head.Value);
				}
				switch (pMethod.Method)
				{
					case "POST":
						HttpContent httpContent = new StringContent(pJsonContent, Encoding.UTF8, "application/json");
						HttpContent content = new StringContent(pJsonContent);
						httpRequestMessage.Content = httpContent;
						break;
				}
				return await _Client.SendAsync(httpRequestMessage);
			}
		}
	}
