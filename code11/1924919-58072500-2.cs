    var request = (HttpWebRequest)WebRequest.Create("http://localhost:3978/api/notify/139dbd54-5bc9-4995-8589-a219fcd8ba8a"); //139dbd54-5bc9-4995-8589-a219fcd8ba8a is userid,you can find it in your conversationReference 
    
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
                   
                }
