            private void PostForm()
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://dork.com/service");
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                string postData ="home=Cosby&favorite+flavor=flies";
                byte[] bytes = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = bytes.Length;
    
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
    
                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                var result = reader.ReadToEnd();
                stream.Dispose();
                reader.Dispose();
            }
