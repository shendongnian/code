    string responseText;
    
    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    {
        using (Stream responseStream = response.GetResponseStream())
        {
        	using(StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding(response.ContentEncoding)))
            {
            	responseText = reader.ReadToEnd();
            }
        }
    }
