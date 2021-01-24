    private async Task<string> UploadFile(string filePath)
    {
        _logger.LogInformation($"Uploading a text file [{filePath}].");
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentNullException(nameof(filePath));
        }
    
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File [{filePath}] not found.");
        }
        using var form = new MultipartFormDataContent();
        using var fileContent = new ByteArrayContent(await File.ReadAllBytesAsync(filePath));
        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
        form.Add(fileContent, "file", Path.GetFileName(filePath));
        form.Add(new StringContent("789"), "userId");
        form.Add(new StringContent("some comments"), "comment");
        form.Add(new StringContent("true"), "isPrimary");
    
        var response = await _httpClient.PostAsync($"{_url}/api/files", form);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<FileUploadResult>(responseContent);
        _logger.LogInformation("Uploading is complete.");
        return result.Guid;
    }
