    string strLive = "https://www.paypal.com/cgi-bin/webscr";
    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strLive); 
    req.Method = "POST";
    req.ContentType = "application/x-www-form-urlencoded";
    byte[] param = Request.BinaryRead(HttpContext.Current.Request.ContentLength);
    string strRequest = Encoding.ASCII.GetString(param);
    strRequest += "&cmd=_notify-validate";
    req.ContentLength = strRequest.Length;
    
    StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
    streamOut.Write(strRequest);
    streamOut.Close();
    StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
    string strResponse = streamIn.ReadToEnd();
    streamIn.Close();
    NameValueCollection ppDetails = HttpUtility.ParseQueryString(strRequest);
    if (strResponse == "VERIFIED"){
    if (ppDetails["payment_status"] == "Completed"){
    //yay, give them goodies
    } else if (strResponse == "INVALID"){
    //log IP and possibly block them from your web services if malicious
    } else {
    //log response/ipn data for manual investigation
    }
    }
    
