      public static string PutWebRequest(string Target, string JsonRequest)
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Target);
                httpWebRequest.Accept = "application/json";
                httpWebRequest.Method = "PUT";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + MYSMARTSHEETSKEY);
    
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(JsonRequest);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return result;
                }
            }
 
