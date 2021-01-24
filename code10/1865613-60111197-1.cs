private static void SendMail()
{
    const string WEBSERVICE_URL = "https://mail.zoho.com/api/accounts/{id}/messages";
    try
    {
        var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
        if (webRequest != null)
        {
            webRequest.Method = "POST";
            webRequest.Headers.Add("Authorization", "{token}}");
            webRequest.ContentType = "application/json";
            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                string json = "{\"fromAddress\": \"{email}}\"," +
                                "\"toAddress\": \"{email}}\"," +
                                "\"subject\": \"subject\"," +
                                "\"content\": \"content\"}";
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            var httpResponse = (HttpWebResponse)webRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine(String.Format("Response: {0}", result));
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
