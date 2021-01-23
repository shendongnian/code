    using (WebClient client = new WebClient()){
        client.OpenRead(dlItem.Link);
        string header_contentDisposition = client.ResponseHeaders["content-disposition"];
        ContentDisposition cd = new ContentDisposition(header_contentDisposition);
        string filename = cd.FileName;
        ...do stuff...
    }
