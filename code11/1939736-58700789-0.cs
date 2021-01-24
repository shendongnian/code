    Stream responseStream = null;
    WebResponse _Response = null;
    Stream responseStream = null;
    HttpWebRequest _Request = null;
    
    try
        {
            _Response = _Request.GetResponse();
            responseStream = _Response.GetResponseStream();
        }
    catch (WebException w)
    {
          //here you can check the reason for the web exception
          WebResponse res = w.Response;
          using (Stream s = res.GetResponseStream())
          {
               StreamReader r= new StreamReader(s);
               string exceptionMessage = r.ReadToEnd(); //here is your error info
          }
    }
    catch {
        //any other exception
    }
