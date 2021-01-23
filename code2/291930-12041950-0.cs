    protected string makeRequest(string area, string id, Dictionary<string, string> parameters)
            {
                // build the url with parameters
                var url = area;
    
                if (!String.IsNullOrEmpty(id)) url += "/" + HttpUtility.UrlEncode(id);
    
                if (parameters != null)
                {
                    bool firstp = true;
                    string[] keys = parameters.Keys.ToArray();
                    foreach (string _key in keys)
                    {
                        if (firstp) url += "?";
                        else url += "&";
    
                        firstp = false;
                        //Double URL encode "&" to prevent restsharp from treating the second half of the string as a new parameter
                        parameters[_key] = parameters[_key].Replace("&", "%26");
                        parameters[_key] = parameters[_key].Replace("+", "%2B");
                        parameters[_key] = parameters[_key].Replace(" ", "%2B");
    
                        url += _key + "=" + parameters[_key]; //HttpUtility.UrlEncode(parameters[_key]);
                    }
                }
    
                var client = new RestClient(rootUri);
    
                var request = new RestRequest(Method.GET);
                
                OAuthBase oAuth = new OAuthBase();
                string nonce = oAuth.GenerateNonce();
                string timeStamp = oAuth.GenerateTimeStamp();
                string normalizedUrl;
                string normalizedRequestParameters;
    
                string sig = oAuth.GenerateSignature(new Uri(string.Format("{0}/{1}", client.BaseUrl, url)),
                    options.ConsumerKey, options.ConsumerSecret,
                    options.AccessToken, options.AccessTokenSecret,
                    "GET", timeStamp, nonce, out normalizedUrl, out normalizedRequestParameters);
    
                sig = HttpUtility.UrlEncode(sig);
    
                request.Resource = string.Format(area);
                
                if (parameters != null)
                {
                    foreach (var p in parameters)
                    {
                        request.AddParameter(p.Key, p.Value);
                    }
                }
    
                request.AddParameter("oauth_consumer_key", options.ConsumerKey);
                request.AddParameter("oauth_token", options.AccessToken);
                request.AddParameter("oauth_nonce", nonce);
                request.AddParameter("oauth_timestamp", timeStamp);
                request.AddParameter("oauth_signature_method", "HMAC-SHA1");
                request.AddParameter("oauth_version", "1.0");
                request.AddParameter("oauth_signature", sig);
                
                var response = client.Execute(request);
    
                return response.Content;
            }
