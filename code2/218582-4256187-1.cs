    string postData = "firstone=" + inputData;
    ASCIIEncoding encoding = new ASCIIEncoding ();
    byte[] byte1 = encoding.GetBytes (postData);
    
    // Set the content type of the data being posted.
    myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
    
    // Set the content length of the string being posted.
    myHttpWebRequest.ContentLength = byte1.Length;
    
    Stream newStream = myHttpWebRequest.GetRequestStream ();
    
    newStream.Write (byte1, 0, byte1.Length);
