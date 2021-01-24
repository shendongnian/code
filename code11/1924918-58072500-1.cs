    var request = (HttpWebRequest)WebRequest.Create("http://localhost:3978/api/notify"); //change the request url as your bot endpoint if you use it on Azure 
    
                request.Method = "POST";
                request.ContentType = "application/json";
    
    
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    var postData = "{\"message\":\"hello! this is a test message from a notify \"}";
    
    
                    streamWriter.Write(postData);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
    
                var response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Console.WriteLine(result);
