    private string PostToFormWithParameters(string query)
    {
        try
        {
            string url = "protocol://mysite.org/page.php/";
            string data = "?pageNumber=" + query; // data you want to send to the form.
            HttpWebRequest WebRequest = (HttpWebRequest)WebRequest.Create(url);
            WebRequest.ContentType = "application/x-www-form-urlencoded";
            byte[] buf = Encoding.ASCII.GetBytes(data);
            WebRequest.ContentLength = buf.Length;
            WebRequest.Method = "POST";    
    
            using (Stream PostData = WebRequest.GetRequestStream())
            {
                PostData.Write(buf, 0, buf.Length);
                HttpWebResponse WebResponse = (HttpWebResponse)WebRequest.GetResponse();
                using (Stream stream = WebResponse.GetResponseStream())
                    using (StreamReader strReader = new StreamReader(stream))
                        return strReader.ReadLine(); // or ReadToEnd() -- https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=netframework-4.8                            
                WebResponse.Close();
           }
    
        }
        catch (Exception e)
        {
            /* throw appropriate exception here */
            throw new Exception();
        }
        return "";
    }
    
    ...
    
    var response = PostToFormWithParameters("5");
