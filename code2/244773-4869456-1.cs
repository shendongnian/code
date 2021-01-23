    public class HashWrapper
    {
        public static string HashPasswordFromJScript(string password)
        {
          string url = "https://mysite.com/DoHash.asp";
    
          string fields = "password=" + password;
          HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
          request.ContentType = "application/x-www-form-urlencoded";
          request.Method = "POST";
          
          using(Stream rs = request.GetRequestStream())
          {
            using (MemoryStream ms = new MemoryStream())
            {
              using(BinaryWriter bw = new BinaryWriter(ms))
              {
                bw.Write(Encoding.UTF8.GetBytes(fields));
                ms.WriteTo(rs);
                ms.Flush();
              }
            }
          }
        
          using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
          {
            if(response.StatusCode == HttpStatusCode.OK)
            {
              using(Stream rs = response.GetResponseStream())
              {
                using (StreamReader rr = new StreamReader(rs))
                {
                  StringBuilder sb = new StringBuilder();
                  int bufferSize = 1024;
                  char[] read = new Char[bufferSize];
                  int count = rr.Read(read, 0, bufferSize);
        
                  while (count > 0)
                  {
                    sb.Append(read, 0, count);
                    count = rr.Read(read, 0, bufferSize);
                  }
                  return sb.ToString();
                }
              }
            }
            return null;
          }
        }
    }
