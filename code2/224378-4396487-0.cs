string username = "user";
string password = "pass";
HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.yoursite.com");
request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.0.3705)";
request.Method = "POST";
using (StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII))
{
    writer.Write("nick=" + username + "&password=" + password);
}
