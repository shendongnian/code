    string url = "serviceurl";
    System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
    System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
     
    if (response.StatusCode == System.Net.HttpStatusCode.OK)
     {
       System.IO.Stream receiveStream = response.GetResponseStream();
       System.IO.StreamReader readStream = null;
     
       if (response.CharacterSet == null)
        readStream = new System.IO.StreamReader(receiveStream);
       else
        readStream = new System.IO.StreamReader(receiveStream, 
     
        System.Text.Encoding.GetEncoding(response.CharacterSet));
     
        string result = readStream.ReadToEnd();
        response.Close();
        readStream.Close();
    }
