csharp
class MyWebClient : WebClient
{
	protected override WebRequest GetWebRequest(Uri address)
	{
		var request = (HttpWebRequest) base.GetWebRequest(address);
		request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
		return request;
	}
}
string url = "http://www.tsetmc.com/Loader.aspx?ParTree=15131F";
WebClient client = new MyWebClient();
// don't set the Accept-Encoding header here; it will be done automatically
string pageSource = client.DownloadString(url);
