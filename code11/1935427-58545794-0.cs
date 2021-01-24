            Dictionary<string, string> paytmParams = new Dictionary<string, string>();
            paytmParams.Add("email", "xxxxxxx@xxxxx.com");
            paytmParams.Add("phone", "xxxxxxxxxxx");
            paytmParams.Add("clientId", "paytm-web-secure");
            paytmParams.Add("scope", "wallet");
            paytmParams.Add("responseType", "token");
            try
            {
                string postData = new JavaScriptSerializer().Serialize(paytmParams);
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Headers.Add("ContentType", "application/json");
                webRequest.Method = "POST";
                using (StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    streamWriter.Write(postData);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                string responseData = string.Empty;
                string statusCode = string.Empty;
                string state = string.Empty;
                using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
                {
                    responseData = responseReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Exception message: " + ex.Message.ToString());
            }`enter code here`
