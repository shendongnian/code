            private string RestCall()
            {
                var result = string.Empty;
                try
                {
                    var client = new RestClient(url + "/rest/api/2/search?jql=");
                    var request = new RestRequest
                    {
                        Method = Method.GET,
                        RequestFormat = DataFormat.Json
                    };
                    request.AddHeader("Authorization", "Basic " + api_token);
                    var response = client.Execute(request);
                    result = response.Content;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return result;
            } 
