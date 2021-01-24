    private const string ResourceFolder = "TestData\\";
    private HttpContent _form;
    
         public void AttachedRatesFile(string fileName)
            {
                _form = string.IsNullOrWhiteSpace(fileName)
                    ? _form = new StringContent(string.Empty)
                    : _form = new StreamContent(File.OpenRead($"{ResourceFolder}{fileName}"));
        
                _content = new MultipartFormDataContent();
                _content.Add(_form, "file", fileName);
                _form.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        
            }
        
        
        public async void WhenThePostRequestExecutesWithContent(string resource, HttpContent content)
        {
            ResponseMessage = await HttpClient.PostAsync(resource, content);
        }
