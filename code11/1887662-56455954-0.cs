    var request = (HttpWebRequest)WebRequest.Create(Endpoint);
    foreach (var item in Headers)
    {
        string headerName = item.Name.ToLower();
        switch (headerName)
        {
            case "contenttype": request.ContentType = item.Value; break;
            case "accept": request.Accept = item.Value; break;
            case "useragent": request.UserAgent = item.Value; break;
            // ... other standard headers
            default:
                // set custom header as usual
                request.Headers.Add(item.Name, item.Value);
                break;
        }
    }
