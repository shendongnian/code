    private async Task DownloadFileFromHttpResponseMessage(HttpResponseMessage response)
    {
        response.EnsureSuccessStatusCode();
    
        var totalBytes = response.Content.Headers.ContentLength;
    
        using (var contentStream = await response.Content.ReadAsStreamAsync())
        {
            await ProcessContentStream(totalBytes, contentStream);
            // Added code
            char[] buffer;
            using (StreamReader sr = new StreamReader(DestinationFilePath))
            {
                buffer = new char[(int)sr.BaseStream.Length];
                await sr.ReadAsync(buffer, 0, (int)sr.BaseStream.Length);
            }
            Debug.WriteLine(new string(buffer)); // Now it prints the response
        }
    }
