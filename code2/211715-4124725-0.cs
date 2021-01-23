string uri = "Path.asmx";
string soap = "soap xml string";
HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
request.Headers.Add("SOAPAction", "\"http://xxxxxx"");
request.ContentType = "text/xml;charset=\"utf-8\"";
request.Accept = "text/xml";
request.Method = "POST";
using (Stream stm = request.GetRequestStream())
{
    using (StreamWriter stmw = new StreamWriter(stm))
    {
        stmw.Write(soap);
    }
}
<b>
using (WebResponse webResponse = request.GetResponse())
{
}
</b>
