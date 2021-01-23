    context.Request.BeginGetRequestStream(new AsyncCallback(Foo), context);
    public void Foo(IAsyncResult asyncResult)
        {
            Context context = (Context)asyncResult.AsyncState;
            try
            {
                HttpWebRequest request = context.Request;
                using (var requestStream = request.EndGetRequestStream(asyncResult))
                using (var writer = new StreamWriter(requestStream))
                {
                    // write to the request stream
                }
                request.BeginGetResponse(new AsyncCallback(ProcessResponse), context);
            }
