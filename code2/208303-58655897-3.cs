static async Task<(bool Success, WebExceptionStatus WebExceptionStatus, HttpStatusCode? HttpStatusCode, string ResponseAsString)> HttpRequestAsync(HttpClient httpClient, string url, string postBuffer = null, CancellationTokenSource cts = null) {
	try {
		HttpResponseMessage resp = null;
		if (postBuffer is null) {
			resp = cts is null ? await httpClient.GetAsync(url) : await httpClient.GetAsync(url, cts.Token);
		} else {
			using (var httpContent = new StringContent(postBuffer)) {
				resp = cts is null ? await httpClient.PostAsync(url, httpContent) : await httpClient.PostAsync(url, httpContent, cts.Token);
			}
		}
		
		var respString = await resp.Content.ReadAsStringAsync();
		return (resp.IsSuccessStatusCode, WebExceptionStatus.Success, resp.StatusCode, respString);
	} catch (WebException ex) {
		WebExceptionStatus status = ex.Status;
		if (status == WebExceptionStatus.ProtocolError) {
			// Get HttpWebResponse so that you can check the HTTP status code.
			using (HttpWebResponse httpResponse = (HttpWebResponse)ex.Response) {
				return (false, status, httpResponse.StatusCode, httpResponse.StatusDescription);
			}
		} else {
			return (false, status, null, ex.ToString()); 
		}
	} catch (TaskCanceledException ex) {
		if (ex.CancellationToken == cts.Token) {
			// a real cancellation, triggered by the caller
			return (false, WebExceptionStatus.RequestCanceled, null, ex.ToString());
		} else {
			// a web request timeout (possibly other things!?)
			return (false, WebExceptionStatus.Timeout, null, ex.ToString());
		}
	} catch (Exception ex) {
		return (false, WebExceptionStatus.UnknownError, null, ex.ToString());
	}
}
This will do a GET or POST depends if `postBuffer` is null or not
if Success is true the response will then be in `ResponseAsString`
if Success is false you can check `WebExceptionStatus`, `HttpStatusCode` and `ResponseAsString` to try to see what went wrong.
I welcome comments on this as I still not sure it covers all cases.
