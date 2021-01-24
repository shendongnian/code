       private async Task<string> ReadTextAsync(string filePath)
        {
            using (var reader = File.OpenText(filePath))
            {
                var fileText = await reader.ReadToEndAsync();
                return fileText;
            }
        }
    
        private async Task WriteTextAsync(string filePath, string value)
        {
            using (StreamWriter writer = File.CreateText(filePath))
            {
                await writer.WriteAsync(value);
            }
        }
