    public HttpResponseMessage MakeRequest(HttpContent request, String path, String headers) {
...
    // set headers 
    foreach (var raw_header in headers.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)) {
    	var index = raw_header.IndexOf(':');
    	if (index <= 0)
    		continue;
    
    	var key = raw_header.Substring(0, index);
    	var value = index + 1 >= raw_header.Length ? string.Empty : raw_header.Substring(index + 1).TrimStart(' ');
    	client.DefaultRequestHeaders.TryAddWithoutValidation(key, value);
    }
