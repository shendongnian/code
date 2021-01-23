     public static void ExecuteGetRequest(string contentType)
            {
                httpcontext = HttpContext.Current;
                request = (HttpWebRequest)WebRequest.Create(BaseUri + Uri + Querystring);
                request.Method = C.HTTP_GET;          
                request.ContentType = contentType;
                request.Headers[C.AUTHORIZATION] = token;
    
                // GetResponse reaises an exception on http status code 400
                // We can pull response out of the exception and continue on our way            
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException ex)
                {
                    response = (HttpWebResponse) ex.Response;
                }
    
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    responseText = reader.ReadToEnd();
                    reader.Close();
                } 
            }
    
            public static void ExecuteJsonGetRequest()
            {
                ExecuteGetRequest(C.CONTENT_JSON);
            }
    
