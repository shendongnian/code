    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;
    namespace testApp
    {
        public class AmadeusTest
        {
            static void Main()
            {
                const string URL = "https://test.api.amadeus.com/v1/shopping/flight-destinations?origin=MAD";
                string token = getToken();
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "");
     
                Task<HttpResponseMessage> response = client.SendAsync(request);
                string myJsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Result.Content.ReadAsStringAsync().Result).ToString();
                JObject jsonObject = JObject.Parse(myJsonResponse);
 
                Console.WriteLine(myJsonResponse);
                Console.WriteLine(jsonObject["data"][0]["destination"]);
                client.Dispose();
        }
        private static string getToken()
        {
            const string apikey = "";
            const string apisecret = "";
            const string tokenURL = "https://test.api.amadeus.com/v1/security/oauth2/token";
 
            string postData = $"grant_type=client_credentials&client_id={apikey}&client_secret={apisecret}";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(tokenURL);
 
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "");
            request.Content = new StringContent(postData,
                                    Encoding.UTF8,
                                    "application/x-www-form-urlencoded");
 
            Task<HttpResponseMessage> response = client.SendAsync(request);
            if (response.Result.IsSuccessStatusCode)
            {
                string myJsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Result.Content.ReadAsStringAsync().Result).ToString();
                JObject jsonObject = JObject.Parse(myJsonResponse);
                client.Dispose();
 
                string token = (string)jsonObject["access_token"];
                return token;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.Result.StatusCode, response.Result.ReasonPhrase);
                return response.Result.ReasonPhrase;
            }
        }
    }
