    HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, <Uri>);
    using (FileStream fs = new FileStream(@"e:\dev\TestHalfB.docx", FileMode.Open))
    {
        byte[] fb = new byte[(int)fs.Length]; // assumes your file size will fit into an int
        await fs.ReadAsync(fb, 0, (int)fs.Length);
        req.Content = new ByteArrayContent(fb);
        req.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
        req.Content.Headers.ContentDisposition.DispositionType = "filename*=UTF-8''TestHalfB.docx";
 
        using (var response = await client.SendAsync(req))
        {
            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();
        }
    }
