    var request = new HttpRequestMessage(HttpMethod.Get, downloadPdfLink);
    request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
    request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
    using (HttpResponseMessage response = await _client.SendAsync(request))
    {
        using (Stream stream = await response.Content.ReadAsStreamAsync())
        {
            Directory.CreateDirectory("./file");
            using (var fs = new FileStream("./file/myfile.pdf", FileMode.Create, FileAccess.Write))
            {
                //stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fs);
            }
        }
    }
