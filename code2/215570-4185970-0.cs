     System.Text.Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
        StreamReader objSR;
    webResponse = (HttpWebResponse)response.GetResponse();
    StreamReader reader = webResponse.GetResponseStream();
    objSR = new StreamReader(objStream, encode, true);
    sResponse = objSR.ReadToEnd();
