    WebRequest request = WebRequest.Create(_url);
    var handle = new ManualResetEvent(false);
    IAsyncResult getResponseResult = request.BeginGetResponse(
        result =>
        {
            using (var response = request.EndGetResponse(result))
            using (var stream = response.GetResponseStream())
            {
                RasImage image = Load(stream);
                // Do something with image.
                handle.Set();
            }
        },
        null
    );
    Console.WriteLine("Waiting for response from '{0}'...", _url);
    handle.WaitOne();
    Console.WriteLine("The stream has been loaded. Press Enter to quit.");
    Console.ReadLine();
