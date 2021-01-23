    public void UploadAsync()
    {
        var data = GetStream("TestFile.txt");
    
        var request = (HttpWebRequest)WebRequest.Create(new Uri("http://example.com/UploadData"));
        request.Method = "POST";
        data.CopyTo(request.GetRequestStream());
    
        request.BeginGetResponse(DataUploadCompleted, request);
                
        Console.WriteLine("Upload Initiated.");
    }
    
    private void DataUploadCompleted(IAsyncResult ar)
    {
        var request = (HttpWebRequest)ar.AsyncState;
        var response = request.EndGetResponse(ar);
        Console.WriteLine("Upload Complete.");
    }
