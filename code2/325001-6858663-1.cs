    // *********************************
    // Sample Client
    // *********************************
    private void UploadButton_Click(object sender, EventArgs e)
    {
        var uri = "http://dev-fileservice/SampleApplication"
        var fullFilename = @"C:\somefile.txt";
        var fileContent = File.ReadAllBytes(fullFilename);
    
        using (var webClient = new WebClient())
        {
            try
            {
                webClient.Proxy = null;
                webClient.Headers.Add(HttpRequestHeader.ContentMd5, this.CalculateFileHash());
                webClient.Headers.Add("X-DaysToKeep", DurationNumericUpDown.Value.ToString());
                webClient.Headers.Add("X-Filename", Path.GetFileName(fullFilename));
                webClient.UploadData(uri, "POST", fileContent);
    
                var fileUri = webClient.ResponseHeaders[HttpResponseHeader.Location];
                Console.WriteLine("File can be downloaded at" + fileUri);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
            }
        }
    }
    
    private string CalculateFileHash()
    {
        var hash = MD5.Create().ComputeHash(File.ReadAllBytes(@"C:\somefile.txt"));
        var sb = new StringBuilder();
    
        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("x2"));
        }
    
        return sb.ToString();
    }
    
    private void DownloadFile()
    {
        var uri = "http://dev-fileservice/SampleApplication/1" // this is the URL returned by the Restful file service
    
        using (var webClient = new WebClient())
        {
            try
            {
                webClient.Proxy = null;
                var fileContent = webClient.DownloadData(uri);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
