   HttpWebRequest request=null;
   Uri uri = new Uri(url);
   request = (HttpWebRequest) WebRequest.Create(uri);
   request.Method = "POST";
   request.ContentType = "application/x-www-form-urlencoded";
   request.ContentLength = postData.Length;
   
   using(Stream writeStream = request.GetRequestStream())
   {
      UTF8Encoding encoding = new UTF8Encoding();
      byte[] bytes = encoding.GetBytes(postData);
      writeStream.Write(bytes, 0, bytes.Length);
   }
   string result=string.Empty;
   using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
   {
       using (Stream responseStream = response.GetResponseStream())
       {
          using (StreamReader readStream = new StreamReader (responseStream,   Encoding.UTF8))
          {
            result = readStream.ReadToEnd();
          }
       }
   }  
