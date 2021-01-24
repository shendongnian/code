request.AddParameter(string name, string value);
an example from what you wrote above would be
csharp
public static IRestResponse CreateNewUser(string enviroment, string email, string password)
        {
            NameValueCollection Env = ValidateEnv(enviroment);
            string baseurlenv = Env["baseApiURL"];
            var enviroments = new EndPointProviders();
            var Client = new RestClient();
            Client.BaseUrl = new Uri(baseurlenv);
            var request = new RestRequest(Method.POST);
            // Resource should just be the path
            request.Resource = string.Format("/v3/members);
            // This is how to add parameters
            request.AddParameter("email", email);
            request.AddParameter("password", password);
            request.AddParameter("terms-and-conditions", "true");
            // This looks correct assuming you are putting your actual x-api-key here
            request.AddHeader("x-api-key", "yxyxyxyx");
            // There is a chance you need to configure the aws api gateway to accept this content type header on that resource. Depends on how locked down you have it
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            IRestResponse response = Client.Execute(request);
            Console.WriteLine(request);
            if (!IsReturnedStatusCodeOK(response))
            {
                throw new HttpRequestException("Request issue -> HTTP code:" + response.StatusCode);
            }
            return response;
        }
