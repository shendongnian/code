               string test = "Test"; 
                WebRequest request = WebRequest.Create("http://localhost/test.aspx"); 
 
                request.Method = "POST"; 
                request.ContentType = "text/xml;charset=utf-8"; 
                request.ContentLength = test.Length; 
 
               using (StreamWriter paramWriter = new StreamWriter(request.GetRequestStream()))
               {
                  paramWriter.Write(test, 0, test.Length);
               }
               WebResponse wres = request.GetResponse();
               StreamReader sr = new StreamReader(wres.GetResponseStream());
               string outdata = sr.ReadToEnd().Trim();
