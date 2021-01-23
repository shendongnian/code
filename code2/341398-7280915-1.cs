    WebRequest request = WebRequest.Create("http://0.gravatar.com/avatar/a5a5ed70fa7c651aa5ec9ca8de57a4b8?s=60&d=identicon&r=G");
    using (WebResponse response = request.GetResponse())
    using (Stream stream = response.GetResponseStream())
    {
        string contentType = response.ContentType;
        // TODO: examine the content type and decide how to name your file
        string filename = "test.jpg";
        // Download the file
        using (Stream file = File.OpenWrite(filename))
        {
            // Remark: if the file is very big read it in chunks
            // to avoid loading it into memory
            byte[] buffer = new byte[response.ContentLength];
            stream.Read(buffer, 0, buffer.Length);
            file.Write(buffer, 0, buffer.Length);
        }
    }
