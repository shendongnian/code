    using (var client = new HttpClient())
    {
        using (var content = new MultipartFormDataContent())
        {
            content.Add(new StringContent("testA"), "A");//string
            content.Add(new StringContent("testB"), "B");
            content.Add(new StringContent("testBB"), "B");//string[]
            content.Add(new StringContent("testC"), "C");
            content.Add(new StringContent("testCC"), "C");
            
            //replace with your own file path, below use an image in wwwroot for example
            string filePath = Path.Combine(_hostingEnvironment.WebRootPath + "\\Images", "myImage.PNG");
            byte[] file = System.IO.File.ReadAllBytes(filePath);
                    
            var byteArrayContent = new ByteArrayContent(file);
            content.Add(byteArrayContent, "file", "myfile.PNG");
            
            var url = "https://locahhost:5001/foo/bar";
            var result = await client.PostAsync(url, content);
        }
    }
