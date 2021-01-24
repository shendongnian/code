C#
public class WebResult
{
	public string Response { get; set; }
	public bool WasSuccessful { get; set; }
	public HttpStatusCode? StatusCode { get; set; }
}
public WebResult GetUrlContents(string url)
{
	try
	{
		var request = (HttpWebRequest)WebRequest.Create(url);
		using (var response = (HttpWebResponse)request.GetResponse())
		using (var responseStream = new StreamReader(response.GetResponseStream()))
		{
			return new WebResult
			{
				WasSuccessful = true,
				Response = responseStream.ReadToEnd(),
				StatusCode = response.StatusCode
			};
		}
	}
	catch (WebException webException)
	{
		return new WebResult
		{
			Response = null,
			WasSuccessful = false,
			StatusCode = (webException.Response as HttpWebResponse)?.StatusCode
		};
	}
}
