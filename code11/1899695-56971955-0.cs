csharp
static private async Task InvokePost(HttpClient httpClient, string url, StringContent content)
{
	var response = await httpClient.PostAsync(url, content);
	var responseHeaders = response.Headers;
	var responseCode = (int)response.StatusCode;
	// Check the error code
	var responseStatus = ISSChecks.CheckHttpResponse(responseCode);
	if (responseStatus.CallSuccess != true)
	{
		JsonString = responseStatus.CallStatus;
	}
	else
	{
		// Collect content from the API call.
		JsonString = await response.Content.ReadAsStringAsync();
	}
}
Within the cmdlet
csharp
// Check the response for errors
Regex responseCheck = new Regex("^(?!2|{).*");
if (responseCheck.IsMatch(_response))
{
	Exception exception = new HttpRequestException(_response);
	ErrorRecord errorRecord = new ErrorRecord(exception, _response, ErrorCategory.InvalidOperation, null);
	ThrowTerminatingError(errorRecord);
}
And it results in an error if there is a problem that gives some idea of what happened.
powershell
Test-Cmdlet : 400 - Bad Request
At line:1 char:32
+ ... Test-Cmdlet -Name Test4 -Description "blah"
+     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    + CategoryInfo          : InvalidOperation: (:) [Test-Cmdlet], HttpRequestException
    + FullyQualifiedErrorId : 400 - Bad Request,Test.Cmdlets.Test-Cmdlet
As always, interested to know how I could have dealt with this better, because I am sure I have probably not used the best or most efficient methods. Thanks.
