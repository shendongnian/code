try
{
    HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
    WebResponse wr = req.GetResponse();
}
catch (WebException wex)
{
    var pageContent = new StreamReader(wex.Response.GetResponseStream())
                          .ReadToEnd();
}
Refer the smiliar case : https://stackoverflow.com/a/18403922/8187800 .
