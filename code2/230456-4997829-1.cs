    namespace Helper {
    public static class FacebookAPI
    {
        public static Dictionary<string, Facebook.JSONObject> DecodePayload(string payload)
        {
            var encoding = new UTF8Encoding();
            var decodedJson = payload.Replace("=", string.Empty).Replace('-', '+').Replace('_', '/');
            var base64JsonArray = Convert.FromBase64String(decodedJson.PadRight(decodedJson.Length + (4 - decodedJson.Length % 4) % 4, '='));
            var json = encoding.GetString(base64JsonArray);
            var jObject = Facebook.JSONObject.CreateFromString(json);            
            return jObject.Dictionary;
        }
        public static bool ValidateSignedRequest(string VALID_SIGNED_REQUEST, out Dictionary<string, Facebook.JSONObject> json)
        {
            string applicationSecret = ConfigurationManager.AppSettings["Secret"];
            string[] signedRequest = VALID_SIGNED_REQUEST.Split('.');
            string expectedSignature = signedRequest[0];
            string payload = signedRequest[1];
            json = DecodePayload(payload);
            // Attempt to get same hash
            var Hmac = SignWithHmac(UTF8Encoding.UTF8.GetBytes(payload), UTF8Encoding.UTF8.GetBytes(applicationSecret));
            var HmacBase64 = ToUrlBase64String(Hmac);
            return (HmacBase64 == expectedSignature);
        }
        private static string ToUrlBase64String(byte[] Input)
        {
            return Convert.ToBase64String(Input).Replace("=", String.Empty)
                                                .Replace('+', '-')
                                                .Replace('/', '_');
        }
        private static byte[] SignWithHmac(byte[] dataToSign, byte[] keyBody)
        {
            using (var hmacAlgorithm = new HMACSHA256(keyBody))
            {
                hmacAlgorithm.ComputeHash(dataToSign);
                return hmacAlgorithm.Hash;
            }
        }
        public static string SerializeDict(Dictionary<string, Facebook.JSONObject> jsonDict)
        {
            // serialize the dictionary
            DataContractSerializer serializer = new DataContractSerializer(jsonDict.GetType());
            using (StringWriter sw = new StringWriter())
            {
                using (XmlTextWriter writer = new XmlTextWriter(sw))
                {
                    // add formatting so the XML is easy to read in the log
                    writer.Formatting = Formatting.Indented;
                    serializer.WriteObject(writer, jsonDict);
                    writer.Flush();
                    return sw.ToString();
                }
            }
        }
        public static string GetAuthToken()
        {
            string appId = ConfigurationManager.AppSettings["AppId"];
            string secret = ConfigurationManager.AppSettings["Secret"];
            string url = String.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&client_secret={1}&grant_type=client_credentials", appId, secret);
            string[] token = HttpGetData(url).Split('=');
            return token[1];
        }
        public static string HttpGetData(string url)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                return (reader.ReadToEnd());
            }
        }
        public static string HttpPostData(string url, string nameValuePair)
        {
            HttpWebRequest request = WebRequest.Create(url + "&" + nameValuePair) as HttpWebRequest;
            request.Method = WebRequestMethods.Http.Post;
            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    return (reader.ReadToEnd());
                }
            }
            catch (WebException ex)
            {
                return ex.Message;
            }
        }
    }}
