    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Add("Accept", "application/json;odata=nometadata");
    client.DefaultRequestHeaders.Add("binaryStringRequestBody", "true");
    client.DefaultRequestHeaders.Add("X-RequestDigest", tFormDigest.Result.FormDigestValue);
    client.MaxResponseContentBufferSize = 2147483647;
</pre>
