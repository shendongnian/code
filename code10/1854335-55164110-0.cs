            public string getCardToken()
            {
                string cardToken="";
                JObject jsonDecodedResponse;
                string cardTokenJson = "";
                string cardTokenEndpoint = "quickbooks/v4/payments/tokens";
                string uri= paymentsBaseUrl + cardTokenEndpoint;
                string cardTokenRequestBody = "{\"card\":{\"expYear\":\"2020\",\"expMonth\":\"02\",\"address\":{\"region\":\"CA\",\"postalCode\":\"94086\",\"streetAddress\":\"1130 Kifer Rd\",\"country\":\"US\",\"city\":\"Sunnyvale\"},\"name\":\"emulate=0\",\"cvc\":\"123\",\"number\":\"4111111111111111\"}}";
               
                // send the request (token api call does not requires Authorization header, rest all payments call do)
                HttpWebRequest cardTokenRequest = (HttpWebRequest)WebRequest.Create(uri);
                cardTokenRequest.Method = "POST";           
                cardTokenRequest.ContentType = "application/json";
                cardTokenRequest.Headers.Add("Request-Id", Guid.NewGuid().ToString());//assign guid
                byte[] _byteVersion = Encoding.ASCII.GetBytes(cardTokenRequestBody);
                cardTokenRequest.ContentLength = _byteVersion.Length;
                Stream stream = cardTokenRequest.GetRequestStream();
                stream.Write(_byteVersion, 0, _byteVersion.Length);
                stream.Close();
                // get the response
                HttpWebResponse cardTokenResponse = (HttpWebResponse)cardTokenRequest.GetResponse();
                using (Stream data = cardTokenResponse.GetResponseStream())
                {
                    cardTokenJson= new StreamReader(data).ReadToEnd();
                    jsonDecodedResponse = JObject.Parse(cardTokenJson);
                    if (!string.IsNullOrEmpty(jsonDecodedResponse.TryGetString("value")))
                    {
                        cardToken = jsonDecodedResponse["value"].ToString();
                    }
                }
                return cardToken;
            }
