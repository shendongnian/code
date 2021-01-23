    public static bool SendAnSMSMessage(string message)
    {
        var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://api.pennysms.com/jsonrpc");
        httpWebRequest.ContentType = "text/json";
        httpWebRequest.Method = "POST";
    
        var serializer = new Newtonsoft.Json.JsonSerializer();
        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            using (var tw = new Newtonsoft.Json.JsonTextWriter(sw))
            {
                 serializer.Serialize(tw, 
                     new {method= "send",
                          @params = new string[]{
                              "IPutAGuidHere", 
                              "msg@MyCompany.com",
                              "MyTenDigitNumberWasHere",
                              message
                          }});
            }
        }
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var responseText = streamReader.ReadToEnd();
            //Now you have your response.
            //or false depending on information in the response
            return true;        
        }
    }
