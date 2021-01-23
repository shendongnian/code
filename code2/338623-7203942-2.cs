    StringBuilder sb = new StringBuilder();
    byte[] buf = new byte[8192];
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://api.bigflix.com/BIGFlixApi.do?parameter=getProductType&partnerID=17&uniqueID=54325345435&timestamp=131286916367&digest=bf53cae8f364cfc1d796489d09e4cfd&nbsp&nbsp<br>");
    HttpWebResponse responce = (HttpWebResponse)request.GetResponse();
    Stream resstream = responce.GetResponseStream();
    string tempString = null;
    int count = 0;
    do
    {
        count = resstream.Read(buf, 0, buf.Length);
        if (count != 0)
        {
            tempString = Encoding.ASCII.GetString(buf, 0, count);
            sb.Append(tempString);
        }
    }
    while (count > 0);
    JavaScriptSerializer ser = new JavaScriptSerializer();
    List<FromFlix> response = ser.Deserialize<List<FromFlix>>(sb.ToString());
    foreach (var item in response)
    {
        Response.Write("ID: " + item.ID + "&" + "Name: " + item.Name + "<br/>");
    }
