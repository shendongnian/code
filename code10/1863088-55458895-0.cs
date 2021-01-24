    const string fileName = "csvFile.csv";
            var filePath = Path.Combine("IntegrationTests", fileName);
            var bytes = File.ReadAllBytes(filePath);
            var form = new MultipartFormDataContent();
            var content = new StreamContent(new MemoryStream(bytes));
            form.Add(content, "csvFile");
            content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "csvFile",
                FileName = fileName
            };
            content.Headers.Remove("Content-Type");
            content.Headers.Add("Content-Type", "application/octet-stream; boundary=----WebKitFormBoundaryMRxYYlVt8KWT8TU3");
            form.Add(content);
            //Act
            var postResponse = await _sellerClient.PostAsync("items/upload", form);
