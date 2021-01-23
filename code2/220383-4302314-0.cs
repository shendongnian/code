    Bytes := Encoding.UTF8.GetBytes(Data); //Where data is your data (XML in my case)
      Request := WebRequest.CreateDefault(Uri.Create(URL)) as HttpWebRequest;
      Request.Method := 'POST';
      Request.ContentLength := Length(Bytes);
      Request.ContentType := 'application/xml'; //Set accordingly
    
      RequestStream := Request.GetRequestStream;
      RequestStream.Write(Bytes, 0, Length(Bytes));
      RequestStream.Close;
    
      Response := Request.GetResponse as HttpWebResponse;
      ResponseStream := StreamReader.Create(Response.GetResponseStream, Encoding.ASCII);
      Result := ResponseStream.ReadToEnd;
      ResponseStream.Close;
