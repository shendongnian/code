    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    private async Task<WebResponse> CallUri(string url, TimeSpan timeout)
	{
	    var uri = new Uri(url);
	    NameValueCollection rawParameters = HttpUtility.ParseQueryString(uri.Query);
	    var parameters = new Dictionary<string, string>();
	    foreach (string p in rawParameters.Keys)
	    {
	        parameters[p] = rawParameters[p];
	    }
	    var client = new HttpClient { Timeout = timeout };
	    HttpResponseMessage response;
	    if (parameters.Count == 0)
	    {
	        response = await client.GetAsync(url);
	    }
	    else
	    {
	        var content = new FormUrlEncodedContent(parameters);
	        string urlMinusParameters = uri.OriginalString.Split('?')[0]; // Parameters always follow the '?' symbol.
	        response = await client.PostAsync(urlMinusParameters, content);
	    }
	    var responseString = await response.Content.ReadAsStringAsync();
	    return new WebResponse(response.StatusCode, responseString);
	}
	private class WebResponse
	{
	    public WebResponse(HttpStatusCode httpStatusCode, string response)
	    {
	        this.HttpStatusCode = httpStatusCode;
	        this.Response = response;
	    }
	    public HttpStatusCode HttpStatusCode { get; }
	    public string Response { get; }
	}
