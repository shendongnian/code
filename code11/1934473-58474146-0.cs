    public async void urlAnalyzer()
    {
        // Append text to Result box
        Result.AppendText("Please wait, inspecting the URL.\n");
        // Initiating WebClient to download webpage
        WebClient inspecter = new WebClient();
        // try-catch to avoid exception in a generic way
        try
        {
            // stroring downloaded page in savedData
            savedData = await inspecter.DownloadStringTaskAsync(webpage);
            // appending downloaded html in Result box
            Result.AppendText(savedData);
        }
        catch
        {
            Result.AppendText("You did not enter any valid URL.");
        }
    }
