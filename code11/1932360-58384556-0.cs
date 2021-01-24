c#
byte[] GetImage(string url)
{
    Stream stream = null;
    byte[] buf;
    try
    {
        WebProxy myProxy = new WebProxy();
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)req.GetResponse();
        stream = response.GetResponseStream();
        using (MemoryStream ms = new MemoryStream())
        {
            stream.CopyTo(ms);
            buf = ms.ToArray();
        }
        stream.Close();
        response.Close();
    }
    catch (Exception exp)
    {
        buf = null;
    }
    return (buf);
}
And for future reference: Debugging these sorts of errors is much easier if you display the exception you see in your `try` / `catch` block, so you have some idea what the error is.
