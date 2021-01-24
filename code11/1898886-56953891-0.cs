    public async Task OnPostAsync()
    {
     
        using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
        {
            var body = await reader.ReadToEndAsync();
            var testValues = JsonConvert.DeserializeObject<TestValues>(body);
            // do something with testValues.test1 etc.
        }
    }
