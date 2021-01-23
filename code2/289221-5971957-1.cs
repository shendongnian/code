    protected override void Initialize()
    {
        string webServiceAddress = @"http://localhost/service/service1.asmx";           
        string methodName = "HelloWorld";
    
        string webServiceMethodUri = string.Format("{0}/{1}", webServiceAddress, methodName);
   
        HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(webServiceMethodUri);
        httpWebRequest.Method = "POST";
    
        httpWebRequest.BeginGetResponse(Response_Completed, httpWebRequest);
               
        base.Initialize();
     }
     void Response_Completed(IAsyncResult result)
     {
        HttpWebRequest request = (HttpWebRequest)result.AsyncState;
        HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);
    
        using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
        {
            string xml = streamReader.ReadToEnd();
    
            using(XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                 reader.MoveToContent();
                 reader.GetAttribute(0);
                 reader.MoveToContent();
                 message = reader.ReadInnerXml();
            }
        }
     }
