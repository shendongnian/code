    client.UploadFileCompleted += new UploadFileCompletedEventHandler (UploadFileCallback);
    ....
    private static void UploadFileCallback(Object sender, UploadFileCompletedEventArgs e)
    {
        string reply = System.Text.Encoding.UTF8.GetString (e.Result);
        Console.WriteLine (reply);
    }
