//url = url server
//authorization = Bearer .....
//body = text json 
//bytesBody = body in byte[]
HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
webRequest.PreAuthenticate = true;
webRequest.Method = "POST";
webRequest.Headers["Cache-Control"] = "no-cache";
webRequest.Accept = "*/*";
webRequest.Headers["Accept-Encoding"] = "gzip, deflate, br";
webRequest.Headers["Accept-Language"] = "en-US,en;q=0.9,pt-BR;q=0.8,pt;q=0.7";
webRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Safari/537.36";
webRequest.ContentType = "application/json";
webRequest.ContentLength = bytesBody.Length;
webRequest.Headers["authorization"] = authorization;
//webRequest.Headers["Origin"] = "chrome-extension://fhbjgbiflinjbdggehcddcbncdddomop";
webRequest.KeepAlive = true;
webRequest.ServicePoint.Expect100Continue = false;
webRequest.Host = host;
using (Stream dataStream = webRequest.GetRequestStream())
{
    dataStream.Write(bytesBody, 0, bytesBody.Length);
    dataStream.Flush();
    dataStream.Close();
}
WebResponse response = webRequest.GetResponse();
                
using (var streamReader = new StreamReader(response.GetResponseStream()))
{
    string result = streamReader.ReadToEnd();
}
response.Close();
