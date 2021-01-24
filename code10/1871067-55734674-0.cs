csharp
using(var httpResponse = (HttpWebResponse)request.GetResponse())
{
    if (httpResponse.StatusCode == HttpStatusCode.OK)
    {
        var responseStream = httpResponse.GetResponseStream();
        if (responseStream != null)
        {
            // Line reached only if httpResponse.GetResponseStream() isn't null
            using (var streamReader = new StreamReader(responseStream))
            {
                var result = streamReader.ReadToEnd();
                ...
            }
        }
    }
    else
    {
        ...
    }
}
