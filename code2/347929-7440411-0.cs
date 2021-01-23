    var wr = WebRequest.Create("http://someurl");
    
    var o = Observable
        .FromAsyncPattern<WebResponse>(wr.BeginGetResponse, wr.EndGetResponse)()
        .ObserveOnDispatcher()
        .Subscribe(response =>
                        {
                            // do stuff with the response
                        },
                    ex =>
                        {
                            //there has been an exception
                        });
