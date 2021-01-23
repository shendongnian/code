    using (WebClient client = new WebClient()){
        client.OpenRead(url);
        string header_contentDisposition = client.ResponseHeaders["content-disposition"];
        string filename = new ContentDisposition(header_contentDisposition).FileName;
        ...do stuff...
    }
