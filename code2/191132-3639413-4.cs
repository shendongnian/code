    WebRequest request = WebRequest.Create(_url);
    IAsyncResult getResponseResult = request.BeginGetResponse(
        result =>
        {
            using (var response = request.EndGetResponse(result))
            using (var stream = response.GetResponseStream())
            {
                RasImage image = Load(stream);
                // Do something with image.
            }
        },
        null
    );
    Console.WriteLine("Waiting for response from '{0}'...", _url);
    getResponseResult.AsyncWaitHandle.WaitOne();
    Console.WriteLine("The stream has been loaded. Press Enter to quit.");
    Console.ReadLine();
