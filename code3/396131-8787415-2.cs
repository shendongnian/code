    using (var stream1 = File.Open("test.txt", FileMode.Open))
    using (var stream2 = File.Open("test.xml", FileMode.Open))
    using (var stream3 = File.Open("test.pdf", FileMode.Open))
    {
        var files = new[] 
        {
            new UploadFile
            {
                Name = "file",
                Filename = "test.txt",
                ContentType = "text/plain",
                Stream = stream1
            },
            new UploadFile
            {
                Name = "file",
                Filename = "test.xml",
                ContentType = "text/xml",
                Stream = stream2
            },
            new UploadFile
            {
                Name = "file",
                Filename = "test.pdf",
                ContentType = "application/pdf",
                Stream = stream3
            }
        };
        var values = new NameValueCollection
        {
            { "key1", "value1" },
            { "key2", "value2" },
            { "key3", "value3" },
        };
        
        byte[] result = UploadFiles("http://localhost:1234/upload", files, values);
    }
