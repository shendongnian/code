    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(remoteFileOrUri));
    request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
    HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
    using (var output = File.OpenWrite(localFileName))
    {
        using (var responseStream = response.GetResponseStream())
        {
            await responseStream.CopyToAsync(output);
        }
    }
