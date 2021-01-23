    for (int index = 0; index < ...; index++)
    {
        int indexCopy = index;
        Uri uri = ...;
        HttpWebRequest itemHtmlRequest = WebRequest.CreateHttp(uri);
        itemHtmlRequest.BeginGetResponse(
            result => OnHTMLFetchComplete(result, indexCopy, itemHtmlRequest),null);
    }
