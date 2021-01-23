     public void ProcessRequest(HttpContext context)
     {           
            WebRequest request = WebRequest.Create("http://widgets.twimg.com/j/2/widget.js");
            request.Method = "GET";
            request.ContentType = "application/javascript";
            using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
            {
                Encoding enc = String.IsNullOrEmpty(response.CharacterSet) ? 
                    Encoding.GetEncoding(1252) : Encoding.GetEncoding(response.CharacterSet);
                using (var reader = new StreamReader(response.GetResponseStream(), enc))
                {
                    var jsContent = reader.ReadToEnd();
                    if (!String.IsNullOrEmpty(jsContent)) {
                        context.Response.ContentType = "application/javascript";
                        context.Response.Write(jsContent);
                    }                    
                }
            }
     }
