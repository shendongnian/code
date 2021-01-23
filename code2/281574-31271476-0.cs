    HttpWebResponse webResponse = null;
    try {
        webResponse = (HttpWebResponse)webRequest.GetResponse();
    } catch (WebException e) {
        webResponse = (HttpWebResponse)e.Response;
        if (webResponse == null) {
            // Handle this.
        }
    }    
    using (webResponse) {
        // Process the response.
    }
